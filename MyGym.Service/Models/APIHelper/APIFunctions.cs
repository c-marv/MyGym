using MyGym.Common;
using MyGym.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyGym.Service.Models.APIHelper
{
    public class APIFunctions
    {
        public static UserInformation UsuarioToUser(Usuario usuario)
        {
            return new UserInformation() 
            { 
                DateOfBirth = usuario.FechaNacimiento,
                Email = usuario.Email,
                FirstName = usuario.Paterno,
                Height = usuario.Estatura,
                LastName = usuario.Materno,
                Names = usuario.Nombre,
                Nick = usuario.Nick,
                Password = usuario.Password,
                PhysicalComplexion = usuario.ComplexionFisica,
                Sex = usuario.Sexo,
                UserID = usuario.UsuarioID,
                Weight = usuario.Peso
            };
        }
        public static Usuario UserToUsuario(UserInformation user)
        {
            return new Usuario() 
            { 
                ComplexionFisica = user.PhysicalComplexion,
                Email = user.Email,
                Estatura = user.Height,
                FechaNacimiento =  user.DateOfBirth,
                Materno = user.LastName,
                Nick = user.Nick,
                Nombre = user.Names,
                Password = user.Password,
                Paterno = user.FirstName,
                Peso =  user.Weight,
                Sexo = user.Sex,
                UsuarioID = user.UserID,
                Nivel = user.LevelActivity
            };
        }
        public static object SuccessResult(object data, string message)
        {
            return new { success = true, data = data, message = message };
        }
        public static object ErrorResult(string message)
        {
            return new { success = false, message = message };
        }
    }
}