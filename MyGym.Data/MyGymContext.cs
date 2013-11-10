using MyGym.Common.Enum;
using MyGym.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Data
{
    public class MyGymContext : DbContext
    {
        private static MyGymContext db = new MyGymContext();
        public static MyGymContext DB
        {
            get { return db; }
            set { db = value; }
        }
        private Random random = new Random();
        public Random Random
        {
            get { return random; }
            set { random = value; }
        }
        // Usuario
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Historial> Historial { get; set; }
        public DbSet<PreferenciaTiempoComida> PreferenciaTiempoComida { get; set; }
        // Dieta
        public DbSet<Alimento> Alimento { get; set; }
        public DbSet<Dieta> Dieta { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<Recomendacion> Recomendacion { get; set; }
        public DbSet<SeConforma> SeConforma { get; set; }
        public DbSet<SeRecomienda> SeRecomienda { get; set; }
        public DbSet<TiempoDeComida> TiempoDeComida { get; set; }
        public DbSet<Tiene> Tiene { get; set; }
        // Rutinas
        public DbSet<Rutina> Rutina { get; set; }
        public DbSet<Ejercicio> Ejercicio { get; set; }
        public DbSet<Actividad> Actividad { get; set; }

        public MyGymContext()
            : base()
        {
            
        }
    }
    public class MyGymInitializer : DropCreateDatabaseAlways<MyGymContext>
    {
        protected override void Seed(MyGymContext context)
        {
            #region Usuario
            context.Usuario.Add(new Usuario()
            {
                ComplexionFisica = ComplexionFisica.Mediana,
                Email = "yerson_kira@hotmail.com",
                Estatura = 1.75,
                FechaNacimiento = new DateTime(1991, 1, 25),
                Materno = "Pariapaza",
                Nick = "Yerson",
                Nombre = "Yerson Marvin",
                Password = "123456",
                Paterno = "Copa",
                Peso = 59,
                Sexo = Common.Enum.Sexo.Masculino,
            });
            context.SaveChanges();
            #endregion
            #region Alimentos

            #endregion
            #region Recomendaciones
            context.Recomendacion.Add(new Recomendacion()
            {
                Nombre = "Arroz con Leche",
                Calorias = 200,
                Proteinas = 300,
                HidratosDeCarbono = 150,
                Grasas = 350
            });
            context.Recomendacion.Add(new Recomendacion()
            {
                Nombre = "Batido Natural con Trozos de Kiwi",
                Calorias = 200,
                Proteinas = 300,
                HidratosDeCarbono = 150,
                Grasas = 350
            });
            context.SaveChanges();
            #endregion
            #region Dieta
            context.Dieta.Add(new Dieta()
            {
                UsuarioID = 1,
                Dia = Dia.Lunes,
                Calorias = 300,
                Grasas = 100,
                Proteinas = 200,
                HidratosCarbono = 200
            });
            #endregion
            #region Tiempos de Comida
            context.TiempoDeComida.Add(new TiempoDeComida()
            {
                Nombre = TiempoComida.Desayuno,
                HoraInicio = new TimeSpan(6, 0, 0),
                HoraFinal = new TimeSpan(10, 0, 0)
            });
            context.TiempoDeComida.Add(new TiempoDeComida()
            {
                Nombre = TiempoComida.Merienda,
                HoraInicio = new TimeSpan(10, 0, 0),
                HoraFinal = new TimeSpan(12, 0, 0)
            });
            context.TiempoDeComida.Add(new TiempoDeComida()
            {
                Nombre = TiempoComida.Almuerzo,
                HoraInicio = new TimeSpan(12, 0, 0),
                HoraFinal = new TimeSpan(14, 0, 0)
            });
            context.TiempoDeComida.Add(new TiempoDeComida()
            {
                Nombre = TiempoComida.Merienda,
                HoraInicio = new TimeSpan(14, 0, 0),
                HoraFinal = new TimeSpan(18, 0, 0)
            });
            context.TiempoDeComida.Add(new TiempoDeComida()
            {
                Nombre = TiempoComida.Cena,
                HoraInicio = new TimeSpan(18, 0, 0),
                HoraFinal = new TimeSpan(20, 0, 0)
            });
            context.SaveChanges();
            #endregion
            #region Ejercicios
            #region Gimnasia
            {
                context.Ejercicio.Add(new Ejercicio()
                {
                    Tipo = TipoEjercicio.Gimnastics,
                    Nombre = "Sentadillas libres",
                    Descripcion=""
                });
                context.SaveChanges();
            }
            #endregion
            #endregion
            base.Seed(context);
        }
    }
}
