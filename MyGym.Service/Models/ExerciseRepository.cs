using MyGym.Common.Enum;
using MyGym.Data;
using MyGym.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyGym.Service.Models
{
    public class ExerciseRepository
    {
        public Ejercicio Get(int exerciseID)
        {
            var exercise = MyGymContext.DB.Ejercicio.Find(exerciseID);
            return exercise;
        }
        /// <summary>
        /// Retorna los ejercicios por un tipo
        /// </summary>
        /// <param name="type">es el tipo de ejercicio</param>
        /// <returns></returns>
        public IEnumerable<Ejercicio> GetByType(TipoEjercicio type)
        {
            return from x in MyGymContext.DB.Ejercicio.ToList() where x.Tipo.Equals(type) select x;
        }
    }
}