using MyGym.Common.Enum;
using MyGym.Data;
using MyGym.Data.Entities;
using MyGym.Service.Controllers.API.ErrorHandler;
using MyGym.Service.Models.APIHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyGym.Service.Models
{
    public class RoutineRepository
    {
        public Random random { get; set; }

        public object GenerateRoutine(int UsuarioId, bool mode)
        {
            var user = MyGymContext.DB.Usuario.Find(UsuarioId);
            if (user == null)
            {
                return APIFunctions.ErrorResult(string.Format(JsonMessage.NotFound, "Usuario"));
            }

            Rutina rutina = new Rutina();
            MyGymContext.DB.Rutina.Add(rutina);
            MyGymContext.DB.SaveChanges();
            DateTime date = new DateTime();
            date = System.DateTime.Now;
            List<Actividad> activities = GetSorted(mode).ToList();
            if (mode)
            {
                for (int i = 0; i < 12; i++)
                {
                    if (i % 4 == 3)
                        activities.Insert(i, new Actividad() { EjercicioID = 1, Fecha = DateTime.Now.AddDays(i), RutinaID = rutina.RutinaID });
                    else
                    {
                        activities[i].Fecha = DateTime.Now.AddDays(i);
                        activities[i].RutinaID = rutina.RutinaID;
                    }
                    MyGymContext.DB.Actividad.Add(activities[i]);
                    MyGymContext.DB.SaveChanges();
                }
                return activities;
            }
            else
            {
                for (int i = 0; i < 21; i++)
                {
                    if (i % 7 == 5 || i % 7 == 6)
                        activities.Insert(i, new Actividad() { EjercicioID = 1, Fecha = DateTime.Now.AddDays(i), RutinaID = rutina.RutinaID });
                    else
                    {
                        activities[i].Fecha = DateTime.Now.AddDays(i);
                        activities[i].RutinaID = rutina.RutinaID;
                    }
                    MyGymContext.DB.Actividad.Add(activities[i]);
                    MyGymContext.DB.SaveChanges();
                }
                return activities;
            }

        }
        private IEnumerable<Actividad> GetSorted(bool sw)
        {
            ExerciseRepository repo = new ExerciseRepository();
            List<List<Ejercicio>> lista = new List<List<Ejercicio>>();
            List<Ejercicio> cardio = repo.GetByType(TipoEjercicio.Cardio).ToList();
            List<Ejercicio> gimastics = repo.GetByType(TipoEjercicio.Gimnastics).ToList();
            List<Ejercicio> weight = repo.GetByType(TipoEjercicio.Weights).ToList();
            lista.Add(cardio);
            lista.Add(gimastics);
            lista.Add(weight);
            List<Actividad> exercices = new List<Actividad>();
            if (sw)
            {
                int j = 0;
                for (int i = 0; i < 3; i++)
                {
                    exercices.Add(new Actividad()
                    {
                        EjercicioID = lista[j % 3][random.Next(lista[j % 3].Count)].EjercicioID
                    });
                    j++;
                    exercices.Add(new Actividad()
                    {
                        EjercicioID = lista[j % 3][random.Next(lista[j % 3].Count)].EjercicioID
                    });
                    j++;
                    exercices.Add(new Actividad()
                    {
                        EjercicioID = lista[j % 3][random.Next(lista[j % 3].Count)].EjercicioID
                    });
                    j++;
                    exercices.Add(new Actividad()
                    {
                        EjercicioID = lista[j % 3][random.Next(lista[j % 3].Count)].EjercicioID
                    });
                    j++;
                    exercices.Add(new Actividad()
                    {
                        EjercicioID = lista[j % 3][random.Next(lista[j % 3].Count)].EjercicioID
                    });
                    j++;
                    exercices.Add(new Actividad()
                    {
                        EjercicioID = lista[j % 3][random.Next(lista[j % 3].Count)].EjercicioID
                    });
                    j += 2;
                }
                return exercices;
            }
            else
            {
                int j = 0;
                for (int i = 0; i < 3; i++)
                {
                    exercices.Add(new Actividad()
                    {
                        EjercicioID = lista[j % 3][random.Next(lista[j % 3].Count)].EjercicioID
                    });
                    j++;
                    exercices.Add(new Actividad()
                    {
                        EjercicioID = lista[j % 3][random.Next(lista[j % 3].Count)].EjercicioID
                    });
                    j++;
                    exercices.Add(new Actividad()
                    {
                        EjercicioID = lista[j % 3][random.Next(lista[j % 3].Count)].EjercicioID
                    });
                    j++;
                    exercices.Add(new Actividad()
                    {
                        EjercicioID = lista[j % 3][random.Next(lista[j % 3].Count)].EjercicioID
                    });
                    j++;
                    exercices.Add(new Actividad()
                    {
                        EjercicioID = lista[j % 3][random.Next(lista[j % 3].Count)].EjercicioID
                    });
                    j++;
                    exercices.Add(new Actividad()
                    {
                        EjercicioID = lista[j % 3][random.Next(lista[j % 3].Count)].EjercicioID
                    });
                    exercices.Add(new Actividad()
                    {
                        EjercicioID = lista[j % 3][random.Next(lista[j % 3].Count)].EjercicioID
                    });
                    j++;
                    exercices.Add(new Actividad()
                    {
                        EjercicioID = lista[j % 3][random.Next(lista[j % 3].Count)].EjercicioID
                    });
                    j++;
                    exercices.Add(new Actividad()
                    {
                        EjercicioID = lista[j % 3][random.Next(lista[j % 3].Count)].EjercicioID
                    });
                    j++;
                    j += 2;
                }
                return exercices;
            }
        }
    }
}