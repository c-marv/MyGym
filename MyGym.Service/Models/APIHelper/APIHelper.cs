using MyGym.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace MyGym.Service.Models.APIHelper
{
    public class APIHelper : DbContext
    {
        private static APIHelper context = new APIHelper();
        public static APIHelper Context { get { return context; } }
        public DbSet<APIObject> API { get; set; }
        public DbSet<APIParameter> Parameters { get; set; }
        public APIHelper() : base()
        {
            Database.SetInitializer(new APIHelperInitializer());
        }
    }
    public class APIHelperInitializer : DropCreateDatabaseAlways<APIHelper>
    {
        protected override void Seed(APIHelper context)
        {
            string currentpath = System.Web.HttpContext.Current.Server.MapPath("~\\Models\\APIHelper");
            #region User API
            context.API.Add(new APIObject()
            {
                Controller = "User",
                Action = "Get",
                JsonGet = System.IO.File.OpenText(currentpath + "\\JsonSamples\\User\\User.Get.json").ReadToEnd(),
                JsonPost = null,
                Sample = System.IO.File.OpenText(currentpath + "\\JsonSamples\\User\\Sample.txt").ReadToEnd(),
                Type = Tipo.GET,
                Description = "Retorna un informacion del usuario",
                Parameters = new List<APIParameter>() { 
                    new APIParameter()
                    {
                        Name = "userid",
                        Description = "Representa el identificador unico de cada usuario",
                        Definition = Models.APIHelper.Definition.URL,
                        Information = "Parametro definido en la URL"
                    }
                }
            });
            context.API.Add(new APIObject()
            {
                Controller = "User",
                Action = "Register",
                JsonGet = File.OpenText(currentpath + "\\JsonSamples\\User\\User.Register.Get.json").ReadToEnd(),
                JsonPost = File.OpenText(currentpath + "\\JsonSamples\\User\\User.Register.Post.json").ReadToEnd(),
                Sample = File.OpenText(currentpath + "\\JsonSamples\\User\\SamplePOST.txt").ReadToEnd(),
                Type = Tipo.POST,
                Description = "Registra un nuevo usuario",
                Parameters = new List<APIParameter>() 
                { 
                    new APIParameter()
                    {
                        Name = "userdata",
                        Description = "Representacion en JSON de los datos del usuario",
                        Definition = Models.APIHelper.Definition.BODY,
                        Information = "Parametro definido el cuerpo (BODY) de la peticion"
                    }
                }
            });
            context.API.Add(new APIObject()
            {
                Controller = "User",
                Action = "LogIn",
                JsonGet = File.OpenText(currentpath + "\\JsonSamples\\User\\User.LogIn.json").ReadToEnd(),
                JsonPost = null,
                Sample = "",
                Type = Tipo.GET,
                Description = "Permite acceder a una cuenta",
                Parameters = new List<APIParameter>() 
                { 
                    new APIParameter()
                    {
                        Name = "user",
                        Description = "Email o Nick asociada a la cuenta de usuario",
                        Definition = Models.APIHelper.Definition.BODY,
                        Information = "Parametro definido el cuerpo (BODY) de la peticion"
                    },
                    new APIParameter()
                    {
                        Name = "password",
                        Description = "Contraseña asociada a la cuenta de usuario",
                        Definition = Models.APIHelper.Definition.BODY,
                        Information = "Parametro definido el cuerpo (BODY) de la peticion"
                    }
                }
            });
            context.API.Add(new APIObject()
            {
                Controller = "User",
                Action = "Delete",
                JsonGet = File.OpenText(currentpath + "\\JsonSamples\\User\\User.Delete.json").ReadToEnd(),
                JsonPost = null,
                Sample = "",
                Type = Tipo.GET,
                Description = "Permite dar de baja a una cuenta de usuario",
                Parameters = new List<APIParameter>() 
                { 
                    new APIParameter()
                    {
                        Name = "userid",
                        Description = "Representa el identificador unico de cada usuario",
                        Definition = Models.APIHelper.Definition.URL,
                        Information = "Parametro definido en la URL"
                    }
                }
            });
            context.API.Add(new APIObject()
            {
                Controller = "User",
                Action = "Update",
                JsonGet = File.OpenText(currentpath + "\\JsonSamples\\User\\User.Update.Get.json").ReadToEnd(),
                JsonPost = File.OpenText(currentpath + "\\JsonSamples\\User\\User.Update.Post.json").ReadToEnd(),
                Sample = "",
                Type = Tipo.POST,
                Description = "Permite actualizar datos del usuario",
                Parameters = new List<APIParameter>() 
                { 
                    new APIParameter()
                    {
                        Name = "userdata",
                        Description = "Representacion en JSON de los datos del usuario",
                        Definition = Models.APIHelper.Definition.BODY,
                        Information = "Parametro definido el cuerpo (BODY) de la peticion"
                    }
                }
            });
            context.SaveChanges();
            #endregion
            #region Diet API
            context.API.Add(new APIObject() 
            { 
                Controller = "Diet",
                Action = "Get",
                JsonGet = System.IO.File.OpenText(currentpath + "\\JsonSamples\\Diet\\Diet.Get.json").ReadToEnd(),
                JsonPost = null,
                Description = "Retorna la dieta de un usuario",
                Sample = "",
                Type = Tipo.GET,
                Parameters = new List<APIParameter>()
                {
                    new APIParameter()
                    {
                        Name = "userid",
                        Description = "Representa el identificador unico de cada usuario del cual se quiere obtener su dieta",
                        Definition = Models.APIHelper.Definition.URL,
                        Information = "Parametro definido en la URL"
                    }, 
                    new APIParameter()
                    {
                        Name = "day",
                        Description = "Representa el dia de la semana del cual se quiere obtener su dieta. Enumerado MyGym.Common.Enum.Dia",
                        Definition = Models.APIHelper.Definition.URL,
                        Information = "Parametro definido en la URL"
                    }, 
                }
            });
            #endregion
            #region Routine API
            context.API.Add(new APIObject()
            {
                Controller = "Routine",
                Action = "Get",
                JsonGet = System.IO.File.OpenText(currentpath + "\\JsonSamples\\Routine\\Routine.Get.json").ReadToEnd(),
                JsonPost = null,
                Description = "Retorna la rutina del usuario",
                Type = Tipo.GET,
                Parameters = new List<APIParameter>()
                {
                    new APIParameter()
                    {
                        Name="userID",
                        Description="Representa el id del usuario, del cual queremos obtener la rutina de ejercicios",
                        Definition=Models.APIHelper.Definition.URL,
                        Information="Parametro definido en la url"
                    },
                    new APIParameter()
                    {
                        Name="mode",
                        Description="Representa el modo en el cual el usuario quiere la rutina de 3 o 5 dias.",
                        Definition=Models.APIHelper.Definition.URL,
                        Information="Parametro definido en la url booleano"
                    }
                }
            });
            #endregion
            #region Exercise API
            context.API.Add(new APIObject()
                {
                    Controller = "Exercise",
                    Action = "Get",
                    JsonGet = System.IO.File.OpenText(currentpath + "\\JsonSamples\\Exercise\\Exercise.Get.json").ReadToEnd(),
                    JsonPost = null,
                    Description = "Retorna el ejercicio solicitado",
                    Type = Tipo.GET,
                    Parameters = new List<APIParameter>()
                    {
                        new APIParameter()
                        {
                            Name="exerciseID",
                            Description="Representa el id del ejercicio",
                            Definition=Models.APIHelper.Definition.URL,
                            Information="Parametro definido en la url"
                        }
                    }
                });
            #endregion
            base.Seed(context);
        }
    }
}