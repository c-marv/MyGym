using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using MyGym.Client.Library.Clases;
using MyGym.Common2;
namespace MyGym.Client.Library
{
    namespace Events
    {
        public static partial class DataMethods
        {
            private static async Task<Data> downloadedInfo(string uriAddress)
            {
                string result = await Internet.DownloadStringAsync(uriAddress);
                Data eventResult = JsonConvert.DeserializeObject<Data>(result);
                if (eventResult != null)
                {
                    
                    return eventResult;
                }
                return null;
            }
            

            public static void Register(string mail,string pass, string nik, string firsname, string lastname,string name,int sex, int complexion,int nivel,double weight, double height, DateTime dateofbirt)
            {  
                //REGISTRO DE UN NUEVO USUARIO
                //los q son int los valido antes de enviar para mandarlos de acuerdo al num q corresponda
                //tbn al momento de enviar para guardar mandar como tipo int a sexo, complexion y nivel
                HttpClient client = new HttpClient();

                MyGym.Common2.Enum.ComplexionFisica compl = MyGym.Common2.Enum.ComplexionFisica.Pequena;
                if (complexion == 1)
                    compl = MyGym.Common2.Enum.ComplexionFisica.Mediana;
                if (complexion == 2)
                    compl = MyGym.Common2.Enum.ComplexionFisica.Grande;
                 
                MyGym.Common2.Enum.Nivel niv=MyGym.Common2.Enum.Nivel.MuyLeve;
                if(nivel==1)
                    niv=MyGym.Common2.Enum.Nivel.Leve;
                if(nivel==2)
                    niv=MyGym.Common2.Enum.Nivel.Moderado;
                if(nivel==3)
                    niv=MyGym.Common2.Enum.Nivel.Intenso;
                if(nivel==4)
                    niv=MyGym.Common2.Enum.Nivel.Excepcional;

                MyGym.Common2.Enum.Sexo sexx = MyGym.Common2.Enum.Sexo.Femenino;
                if (sex == 1)
                    sexx = MyGym.Common2.Enum.Sexo.Masculino;

                UserInformation user = new UserInformation()
                {
                    DateOfBirth = dateofbirt,
                    Email = mail,
                    FirstName = firsname,
                    Height = height,
                    LastName = lastname,
                    LevelActivity = niv,
                    Names = name,
                    Nick = nik,
                    Password = pass,                    
                    PhysicalComplexion = compl,
                    Sex = sexx,
                    Weight = weight
                };
                string json=JsonConvert.SerializeObject(user);
                client.BaseAddress = new Uri("http://localhost:5638");
                var content = new FormUrlEncodedContent(new[] { 
                    new KeyValuePair<string, string> ("userdata",json)
                });
                var result = client.PostAsync("/User/Register", content).Result;
                string jsonresult = result.Content.ReadAsStringAsync().Result;
            }

            public static Data GetUser(string nick, string pass)
            {
                //LOGIN Permite acceder a una cuenta
                //devuelve los datos de usuario si se envia nick y password
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri("http://localhost:5638");
                var content = new FormUrlEncodedContent(new[] { 
                new KeyValuePair<string, string> ("logindata", JsonConvert.SerializeObject(new { user = nick, password = pass}))
            });
                var result = client.PostAsync("/User/LogIn", content).Result;
                string jsonresult = result.Content.ReadAsStringAsync().Result;

                DataResult eventResult = JsonConvert.DeserializeObject<DataResult>(jsonresult);
                if (eventResult != null)
                {
                    Data infoUser = new Data();
                    infoUser = eventResult.data;

                    return infoUser;
                }
                return null;
            }
            public static Data GetUser(int userid)
            {
                //RETORNA LA INFORMACION DE USUARIO SI SE ENVIA SU ID
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5638/User/Get?userid=" + userid);

                var result = client.GetStringAsync(client.BaseAddress).Result;

                DataResult eventResult = JsonConvert.DeserializeObject<DataResult>(result);
                if (eventResult != null)
                {
                    Data infoUser = new Data();
                    infoUser = eventResult.data;

                    return infoUser;
                }
                return null;
            }
            public static void Update(int myId, string mail, string pass, string nik, string firsname, string lastname, string name, int complexion, int nivel, double weight, double height)
            {
                //ACTUALIZANDO DATOS NO SE PERMITE CAMBIA FECHA DE NACIMIENTO NI SEXO
                //los q son int los valido antes de enviar para mandarlos de acuerdo al num q corresponda
                //tbn al momento de enviar para guardar mandar como tipo int a: complexion y nivel
                HttpClient client = new HttpClient();

                MyGym.Common2.Enum.ComplexionFisica compl = MyGym.Common2.Enum.ComplexionFisica.Pequena;
                if (complexion == 1)
                    compl = MyGym.Common2.Enum.ComplexionFisica.Mediana;
                if (complexion == 2)
                    compl = MyGym.Common2.Enum.ComplexionFisica.Grande;

                MyGym.Common2.Enum.Nivel niv = MyGym.Common2.Enum.Nivel.MuyLeve;
                if (nivel == 1)
                    niv = MyGym.Common2.Enum.Nivel.Leve;
                if (nivel == 2)
                    niv = MyGym.Common2.Enum.Nivel.Moderado;
                if (nivel == 3)
                    niv = MyGym.Common2.Enum.Nivel.Intenso;
                if (nivel == 4)
                    niv = MyGym.Common2.Enum.Nivel.Excepcional;


                UserInformation user = new UserInformation()
                {
                    UserID = myId,

                    Email = mail,
                    FirstName = firsname,
                    Height = height,
                    LastName = lastname,
                    LevelActivity = niv,
                    Names = name,
                    Nick = nik,
                    Password = pass,
                    PhysicalComplexion = compl,

                    Weight = weight
                };
                client.BaseAddress = new Uri("http://localhost:5638");
                var content = new FormUrlEncodedContent(new[] { 
                new KeyValuePair<string, string> ("userdata",JsonConvert.SerializeObject(user))
            });
                var result = client.PostAsync("/User/Update ", content).Result;
                string jsonresult = result.Content.ReadAsStringAsync().Result;
             
            }


            public static void Delete(int userid)
            {
                //ELIMINA USUARIO
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5638/User/Delete?userid=" + userid);

                var result = client.GetStringAsync(client.BaseAddress).Result;

            }
            public static List<Diet> GetDiets(int userid)
            {
                //RETORNA LAS DIETAS DEL DIA ACTUAL DE UN DETERMINADO USUARIO
                var diaActual = DateTime.Today.DayOfWeek.ToString();

                MyGym.Common2.Enum.Dia dia = MyGym.Common2.Enum.Dia.Lunes;
                if (diaActual.Equals("Tuesday"))
                    dia = MyGym.Common2.Enum.Dia.Martes;
                if (diaActual.Equals("Wednesday"))
                    dia = MyGym.Common2.Enum.Dia.Miercoles;
                if (diaActual.Equals("Thursday"))
                    dia = MyGym.Common2.Enum.Dia.Jueves;
                if (diaActual.Equals("Friday"))
                    dia = MyGym.Common2.Enum.Dia.Viernes;
                if (diaActual.Equals("Saturday"))
                    dia = MyGym.Common2.Enum.Dia.Sabado;
                if (diaActual.Equals("Sunday"))
                    dia = MyGym.Common2.Enum.Dia.Domingo;

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5638/Diet/Get?userid=" + userid + "&day=" + dia);

                var result = client.GetStringAsync(client.BaseAddress).Result;

                DietResult eventResult = JsonConvert.DeserializeObject<DietResult>(result);
                if (eventResult != null)
                {
                    List<Diet> DietList = new List<Diet>();
                    DietList = eventResult.data;

                    return DietList;
                }
                return null;
            }

        }
    }
}
