using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyGym.Service.Controllers.API.ErrorHandler
{
    public class JsonMessage
    {
        public const string Success = "";
        public const string NotFound = "{0} no encontrado";
        public const string Ambiguous = "";
        public const string BadRequest = "{0} no es una peticion valida";
        public const string Error = "No se ha podido cambiar la prodiedad {0}";
        public const string ErrorLogin = "Error al loguearse";
        public const string UnidentifiqueError = "Error desconocido";
        public const string CannotChangeProperty = "No se puede cambiar el valor de lapropiedad";
    }
}