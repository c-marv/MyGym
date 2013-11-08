using MyGym.Common;
using MyGym.Common.Enum;
using MyGym.Data;
using MyGym.Data.Entities;
using MyGym.Service.Controllers.API.ErrorHandler;
using MyGym.Service.Models.APIHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MyGym.Service.Models
{
    public class DietRepository
    {
        public void DeleteDiet(int userid)
        {
            Usuario user = MyGymContext.DB.Usuario.Find(userid);

            foreach (var item in user.Dieta)
            {
                var dieta = MyGymContext.DB.Tiene.FirstOrDefault(e => e.DietaID == item.DietaID);
                MyGymContext.DB.Tiene.Remove(dieta);
                MyGymContext.DB.SaveChanges();
            }
            user.Dieta = new HashSet<Dieta>();
            MyGymContext.DB.SaveChanges();
        }
        public object GetUserDiet(int userid, string day)
        {
            Dia dia = (Dia)Enum.Parse(typeof(Dia), day);
            var diet = MyGymContext.DB.Dieta.FirstOrDefault(item => item.UsuarioID == userid & item.Dia == dia);
            if (diet == null)
            {
                return APIFunctions.ErrorResult(string.Format(JsonMessage.NotFound, "Dieta"));
            }
            var recomendations = MyGymContext.DB.Tiene.Where(item => item.DietaID == diet.DietaID);
            if (recomendations.Count() > 0)
            {
                return APIFunctions.SuccessResult(
                recomendations.Select(item => new UserDiet()
                {
                    DietID = diet.DietaID,
                    ImageURL = string.Format("http://localhost:8000/images/{0}.jpg", item.RecomendacionID),
                    MealTime = new List<TiempoComida>(item.Recomendacion.SeRecomiendaEn.Select(tc => tc.TiempoDeComida.Nombre)),
                    Name = item.Recomendacion.Nombre,
                    RecomendationID = item.RecomendacionID
                }), JsonMessage.Success);
            }
            return APIFunctions.ErrorResult(JsonMessage.Error);
        }
        public object GenerateDiet(int userid, UserInformation userdata)
        {
            DateTime lastupdate = GetLastUpdate(userid);
            if (DateTime.Now.Month > lastupdate.Month)
            {
                var user = MyGymContext.DB.Usuario.Find(userid);
                DateTime olddateofbirth = user.FechaNacimiento;
                double oldweigth = user.Peso;
                double oldheight = user.Estatura;
                if (userdata.DateOfBirth != null) user.FechaNacimiento = userdata.DateOfBirth;
                if (userdata.Weight != default(double)) user.Peso = userdata.Weight;
                if (userdata.Height != default(double)) user.Estatura = userdata.Height;
                MyGymContext.DB.SaveChanges();
                if (user.FechaNacimiento != olddateofbirth | user.Peso != oldweigth | user.Estatura != oldheight)
                {
                    new DietRepository().CreateDiet(user.UsuarioID);
                }
                return APIFunctions.SuccessResult(new object(), JsonMessage.Success);
            }
            return APIFunctions.ErrorResult(JsonMessage.CannotChangeProperty);
        }
        public DateTime GetLastUpdate(int userid)
        {
            var records = MyGymContext.DB.Historial.Where(item => item.UsuarioID == userid).OrderBy(item => item.Fecha).FirstOrDefault();
            if (records == null)
            {
                return default(DateTime);
            }
            return records.Fecha;
        }
        public void CreateDiet(int userid)
        {
            // borramos dieta anterior
            this.DeleteDiet(userid);
            Usuario user = MyGymContext.DB.Usuario.Find(userid);
            // Obtenemos los tiempos de comida
            var tcuser = user.TiemposDeComida.Select(s => s.TiempoDeComidaID);
            int tiemposdecomida = tcuser.Count(); 
            // Indice de masa corporal del usuario
            double userIMC = GetIMC(user.Peso, user.Estatura);
            // Estdado nutricional del usuario
            EstadoNutricional userstatus = GetNutritionalStatus(userIMC);
            // Porcentaje de aumento o disminucion de hidratos de carbono y grasas
            double porcentaje = 0;
            // Gasto energetico en reposo kilocalorias/dia
            double GER = 0;
            // Edad del usuario
            int userage = DateTime.Now.Year - user.FechaNacimiento.Year;

            if (userstatus != EstadoNutricional.Normal)
            {
                // Peso minimo recomendable 
                double minweigth = 18.5 * Math.Pow(user.Estatura, 2);
                // Peso maximo optimo
                double maxweigth = 24.99 * Math.Pow(user.Estatura, 2);
                if (user.Peso < minweigth)
                {
                    porcentaje = (18.5 - userIMC) / 2.51;
                    GER = GetGER(minweigth, userage, user.Sexo);
                }
                else if (user.Peso > maxweigth)
                {
                    porcentaje = (userIMC - 24.99) / -15.01;
                    GER = GetGER(maxweigth, userage, user.Sexo);
                }
            }
            else
            {
                GER = GetGER(user.Peso, userage, user.Sexo);
            }

            double kcaloriasbyweek, proteinasbyweek, grasasbyweek, hidcarbyweek;
            kcaloriasbyweek = 0;
            proteinasbyweek = 0;
            grasasbyweek = 0;
            hidcarbyweek = 0;
            Dia[] dias = { Dia.Lunes, Dia.Martes, Dia.Miercoles, Dia.Jueves, Dia.Viernes, Dia.Sabado, Dia.Domingo };
            // calorias quemadas por dia en kilocalorias
            double[] caloriesbyday = { 100, 200, 300, 400, 500, 600, 700 };

            double activityfactor = GetActivityFactor(user.Nivel, user.Sexo);

            for (int i = 0; i < dias.Length; i++)
            {
                // Kilocalorias por dia
                double kcal = (caloriesbyday[i] + GER) * activityfactor;
                // Proteinas en gramos
                double proteinas = (0.15 * kcal) / 4;
                // Grasas en gramos
                double grasas = (0.25 * kcal) / 4;
                grasas += grasas * porcentaje;
                // Hidratos de carbono en gramos
                double hidratosdecarbono = (0.6 * kcal) / 9;
                hidratosdecarbono += hidratosdecarbono * porcentaje;
                // Recomendaciones en base a las proteinas, grasas e hidratos de carbono necesarias
                var recomendations = GetRecomendaciones(
                                        kcal / tiemposdecomida,
                                        proteinas / tiemposdecomida,
                                        hidratosdecarbono / tiemposdecomida,
                                        grasas / tiemposdecomida,
                                        0.1
                                    );
                // Adicionar la nueva dieta del dia
                var newdiet = MyGymContext.DB.Dieta.Add(new Dieta() 
                { 
                    Calorias = kcal,
                    Dia = dias[i],
                    Grasas = grasas,
                    HidratosCarbono = hidratosdecarbono,
                    Proteinas = proteinas,
                    UsuarioID = user.UsuarioID,
                    Usuario = user
                });
                MyGymContext.DB.SaveChanges();
                // Adicionar las recomendaciones a la dieta
                foreach (var item in recomendations)
                {
                    var tcrec = item.SeRecomiendaEn.Select(s => s.TiempoDeComidaID);
                    if ((tcrec.Intersect(tcuser)).Count() > 0)
                    {
                        MyGymContext.DB.Tiene.Add(new Tiene() 
                        { 
                            DietaID = newdiet.DietaID,
                            RecomendacionID = item.RecomendacionID
                        });
                        MyGymContext.DB.SaveChanges();
                    }
                }
                // Promedio semanal
                kcaloriasbyweek += kcal;
                proteinasbyweek += proteinas;
                hidcarbyweek += hidratosdecarbono;
                grasasbyweek += grasas;
            }
            // Adicionamos al historial
            MyGymContext.DB.Historial.Add(new Historial() 
            { 
                Estatura = user.Estatura,
                Calorias = kcaloriasbyweek / 7,
                EstadoNutricional = userstatus,
                Fecha = DateTime.Now, 
                Grasas = grasasbyweek / 7,
                HidratosCarbono = hidcarbyweek / 7,
                IMC = userIMC,
                Peso = user.Peso,
                Proteinas = proteinasbyweek / 7,
                UsuarioID = user.UsuarioID
            });
            MyGymContext.DB.SaveChanges();
        }
        private double GetActivityFactor(Nivel level, Sexo sex)
        {
            switch (level)
            {
                case Nivel.MuyLeve:
                    return 1.3;
                case Nivel.Leve:
                    return sex == Sexo.Masculino ? 1.6 : 1.5;
                case Nivel.Moderado:
                    return sex == Sexo.Masculino ? 1.7 : 1.6;
                case Nivel.Intenso:
                    return sex == Sexo.Masculino ? 2.1 : 1.9;
                default:
                    return sex == Sexo.Masculino ? 2.4 : 2.2;
            }
        }
        private IEnumerable<Recomendacion> GetRecomendaciones(double calorias, double proteinas, double hidratoscarbono, double grasas, double error)
        {
            double proteinasmin, proteinasmax, grasasmin, grasasmax, hidcarmin, hidcarmax, caloriasmin, caloriasmax;
            proteinasmin = proteinas - (proteinas * error);
            proteinasmax = proteinas + (proteinas * error);
            grasasmin = grasas - (grasas * error);
            grasasmax = grasas + (grasas * error);
            hidcarmin = hidratoscarbono - (hidratoscarbono * error);
            hidcarmax = hidratoscarbono + (hidratoscarbono * error);
            caloriasmin = calorias - (calorias * error);
            caloriasmax = calorias + (calorias * error);
            return MyGymContext.DB.Recomendacion.Where(
                item => CumpleRequerimientos(
                    item,
                    caloriasmin, caloriasmax,
                    proteinasmin, proteinasmax,
                    grasasmin, grasasmax,
                    hidcarmin, hidcarmax));
        }
        private bool CumpleRequerimientos(
            Recomendacion recomendacion,
            double caloriasmin, double caloriasmax,
            double proteinasmin, double proteinasmax,
            double grasasmin, double grasasmax,
            double hidcarmin, double hidcarmax)
        {
            return recomendacion.Calorias >= caloriasmin & recomendacion.Calorias <= caloriasmax &
                recomendacion.Proteinas >= proteinasmin & recomendacion.Proteinas <= proteinasmax &
                recomendacion.Grasas >= grasasmin & recomendacion.Grasas <= grasasmax &
                recomendacion.HidratosDeCarbono >= hidcarmin & recomendacion.HidratosDeCarbono <= hidcarmax;
        }
        private double GetGER(double peso, int userage, Sexo sexo)
        {
            if (sexo == Common.Enum.Sexo.Masculino)
            {
                if (userage < 3)
                {
                    return (6.90 * peso) - 54;
                }
                else if (userage < 10)
                {
                    return (22.7 * peso) + 495;
                }
                else if (userage < 18)
                {
                    return (17.5 * peso) + 651;
                }
                else if (userage < 30)
                {
                    return (15.3 * peso) + 679;
                }
                else if (userage < 60)
                {
                    return (11.6 * peso) + 879;
                }
                else
                {
                    return (13.5 * peso) + 487;
                }
            }
            else
            {
                if (userage < 3)
                {
                    return (61.0 * peso) - 51;
                }
                else if (userage < 10)
                {
                    return (22.5 * peso) + 499;
                }
                else if (userage < 18)
                {
                    return (12.2 * peso) + 746;
                }
                else if (userage < 30)
                {
                    return (14.7 * peso) + 496;
                }
                else if (userage < 60)
                {
                    return (14.7 * peso) + 746;
                }
                else
                {
                    return (10.5 * peso) + 596;
                }
            }
        }
        private double GetIMC(double peso, double altura)
        {
            return peso / Math.Pow(altura, 2);
        }
        private EstadoNutricional GetNutritionalStatus(double imc)
        {
            if (imc < 15.99)
            {
                return EstadoNutricional.Infrapeso;
            }
            else if (imc < 16)
            {
                return EstadoNutricional.DelgadezSevera;
            }
            else if (imc < 16.99)
            {
                return EstadoNutricional.DelgadezModerada;
            }
            else if (imc < 18.49)
            {
                return EstadoNutricional.DelgadezNoMuyPronunciada;
            }
            else if (imc < 24.99)
            {
                return EstadoNutricional.Normal;
            }
            else if (imc <= 25)
            {
                return EstadoNutricional.Sobrepeso;
            }
            else if (imc < 29.99)
            {
                return EstadoNutricional.Preobeso;
            }
            else if (imc <= 30)
            {
                return EstadoNutricional.Obeso;
            }
            else if (imc < 34.99)
            {
                return EstadoNutricional.ObesoTipoI;
            }
            else if (imc < 39.99)
            {
                return EstadoNutricional.ObesoTipoII;
            }
            else
            {
                return EstadoNutricional.ObesoTipoIII;
            }
        }
    }
}