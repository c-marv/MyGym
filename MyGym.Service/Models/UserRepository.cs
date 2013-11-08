using MyGym.Common;
using MyGym.Data;
using MyGym.Data.Entities;
using MyGym.Service.Controllers.API.ErrorHandler;
using MyGym.Service.Models.APIHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MyGym.Service.Models
{
    public class UserRepository
    {
        public object Add(UserInformation user)
        {
            try
            {
                //UserInformation user = JsonConvert.DeserializeObject<UserInformation>(userjson);
                if (!ValidateUser(user.Email, user.Nick))
                {
                    return APIFunctions.ErrorResult(JsonMessage.NotFound);
                }
                Usuario newuser = MyGymContext.DB.Usuario.Add(APIFunctions.UserToUsuario(user));
                MyGymContext.DB.SaveChanges();
                // Generamos la dieta
                new DietRepository().CreateDiet(newuser.UsuarioID);
                return APIFunctions.SuccessResult(newuser.UsuarioID, JsonMessage.Success);
            }
            catch (Exception ex)
            {
                return APIFunctions.ErrorResult(ex.Message);
            }
        }
        public object Get(int userid)
        {
            Usuario user = MyGymContext.DB.Usuario.Find(userid);
            if (user == null)
            {
                return APIFunctions.ErrorResult(string.Format(JsonMessage.NotFound, "Usuario"));
            }
            return APIFunctions.SuccessResult(APIFunctions.UsuarioToUser(user), JsonMessage.Success);
        }
        public object Update(UserInformation user)
        {
            try
            {
                Usuario olduser = MyGymContext.DB.Usuario.Find(user.UserID);
                if (olduser == null)
                {
                    return APIFunctions.ErrorResult(string.Format(JsonMessage.NotFound, "Usuario"));
                }
                if (user.PhysicalComplexion != olduser.ComplexionFisica) olduser.ComplexionFisica = user.PhysicalComplexion;
                if (user.LastName != null & user.LastName != string.Empty) olduser.Materno = user.LastName;
                if (user.Names != null & user.Names != string.Empty) olduser.Nombre = user.Names;
                if (user.Password != null & user.Password != string.Empty) olduser.Password = user.Password;
                if (user.FirstName != null & user.FirstName != string.Empty) olduser.Paterno = user.FirstName;
                if (user.Sex != olduser.Sexo) olduser.Sexo = user.Sex;

                if (user.Nick != null & user.Nick != string.Empty)
                {
                    Usuario finduser = MyGymContext.DB.Usuario.FirstOrDefault(item => item.Nick == user.Nick & item.UsuarioID != olduser.UsuarioID);
                    if (finduser != null)
                    {
                        return APIFunctions.ErrorResult(string.Format(JsonMessage.Error, "Nick"));
                    }
                    olduser.Nick = user.Nick;
                }
                if (user.Email != null & user.Email != string.Empty)
                {
                    Usuario finduser = MyGymContext.DB.Usuario.FirstOrDefault(item => item.Email == user.Email & item.UsuarioID != olduser.UsuarioID);
                    if (finduser != null)
                    {
                        return APIFunctions.ErrorResult(string.Format(JsonMessage.Error, "Email"));
                    }
                    olduser.Email = user.Email;
                }

                //DateTime olddateofbirth = olduser.FechaNacimiento;
                //double oldweigth = olduser.Peso;
                //double oldheight = olduser.Estatura;

                //if (user.DateOfBirth != null | user.Weight != default(double) | user.Height != default(double))
                //{ 
                //    if (user.DateOfBirth != null) olduser.FechaNacimiento = user.DateOfBirth;
                //    if (user.Weight != default(double)) olduser.Peso = user.Weight;
                //    if (user.Height != default(double)) olduser.Estatura = user.Height;
                //}
                MyGymContext.DB.SaveChanges();
                //if (olduser.FechaNacimiento != olddateofbirth | olduser.Peso != oldweigth | olduser.Estatura != oldheight)
                //{
                //    new DietRepository().CreateDiet(olduser.UsuarioID);
                //}
                return APIFunctions.SuccessResult(new { userid = olduser.UsuarioID }, JsonMessage.Success);
            }
            catch (Exception ex)
            {
                return APIFunctions.ErrorResult(ex.Message);
            }
        }
        public object Delete(int userid)
        {
            try
            {
                Usuario user = MyGymContext.DB.Usuario.Find(userid);
                if (user == null)
                {
                    return APIFunctions.ErrorResult(string.Format(JsonMessage.NotFound, "Usuario"));
                }
                MyGymContext.DB.Usuario.Remove(user);
                MyGymContext.DB.SaveChanges();
                return APIFunctions.SuccessResult(new object(), JsonMessage.Success);
            }
            catch (Exception ex)
            {
                return APIFunctions.ErrorResult(ex.Message);
            }
        }
        private bool ValidateUser(string email, string nick)
        {
            Usuario user = MyGymContext.DB.Usuario.FirstOrDefault(item => item.Email == email || item.Nick == nick);
            return user == null;
        }
        public object LogIn(string user, string password)
        {
            var result = MyGymContext.DB.Usuario.FirstOrDefault(item => (item.Email == user | item.Nick == user) & item.Password == password);
            if (result == null)
            {
                return APIFunctions.ErrorResult(JsonMessage.ErrorLogin);
            }
            return APIFunctions.SuccessResult(APIFunctions.UsuarioToUser(result), JsonMessage.Success);
        }
    }
}