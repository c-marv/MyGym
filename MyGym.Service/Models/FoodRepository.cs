using MyGym.Data;
using MyGym.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyGym.Service.Models
{
    public class FoodRepository
    {
        public IEnumerable<Alimento> GetAll()
        {
            return MyGymContext.DB.Alimento.AsEnumerable();
        }
        public Alimento Get(int alimentoid)
        {
            return MyGymContext.DB.Alimento.Find(alimentoid);
        }
        public void Delete(int foodid)
        {
            var food = Get(foodid);
            if (food != null)
            {
                MyGymContext.DB.Alimento.Remove(food);
            }
        }
        public void Update(int foodid, Alimento food)
        {
            try
            {
                var f = Get(foodid);
                if (f != null)
                {
                    f.Calorias = food.Calorias;
                    f.Grasas = food.Grasas;
                    f.GrupoID = food.GrupoID;
                    f.HidratosDeCarbono = food.HidratosDeCarbono;
                    f.Nombre = food.Nombre;
                    f.Proteinas = food.Proteinas;
                    MyGymContext.DB.SaveChanges();
                }
            }
            catch (Exception) { }
        }
        public int Add(Alimento food)
        {
            try
            {
                MyGymContext.DB.Alimento.Add(food);
                return MyGymContext.DB.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}