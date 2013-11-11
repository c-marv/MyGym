using MyGym.Data;
using MyGym.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyGym.Service.Models
{
    public class GroupRepository
    {
        public IEnumerable<Grupo> GetAll()
        {
            return MyGymContext.DB.Grupo.AsEnumerable();
        }
        public int Add(Grupo group)
        {
            try
            {
                MyGymContext.DB.Grupo.Add(group);
                return MyGymContext.DB.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public Grupo Get(int grupoid)
        {
            return MyGymContext.DB.Grupo.Find(grupoid);
        }
        public void Delete(int grupoid)
        {
            Grupo group = Get(grupoid);
            if (group != null)
            {
                MyGymContext.DB.Grupo.Remove(group);
                MyGymContext.DB.SaveChanges();
            }
        }
        public void Update(int groupid, Grupo group)
        {
            Grupo g = Get(groupid);
            if (group != null)
            {
                g.Nombre = group.Nombre;
                g.RecomendacionMaxima = group.RecomendacionMaxima;
                g.RecomendacionMinima = group.RecomendacionMinima;
                MyGymContext.DB.SaveChanges();
            }
        }

    }
}