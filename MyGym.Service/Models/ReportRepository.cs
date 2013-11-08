using MyGym.Common;
using MyGym.Data;
using MyGym.Service.Controllers.API.ErrorHandler;
using MyGym.Service.Models.APIHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyGym.Service.Models
{
    public class ReportRepository
    {
        public object GetUserRecord(int userid, string filter, int weekscount)
        {
            IEnumerable<UserRecord> datas = default(IEnumerable<UserRecord>);
            if (filter.Equals("month"))
            {
                datas = MyGymContext.DB.Historial.Where(
                            item => item.UsuarioID == userid).Select(e =>
                                new UserRecord()
                                {
                                    Weight = e.Peso,
                                    Heigth = e.Estatura,
                                    Date = e.Fecha,
                                    NutritionalStatus = e.EstadoNutricional
                                });
            }
            else if (filter.Equals("week"))
            {
                var query = MyGymContext.DB.Historial.Where(
                            item => item.UsuarioID == userid).
                                OrderBy(item => item.Fecha);
                if (query.Count() > weekscount)
                {
                    datas = query.Take(weekscount).
                                        Select(e => new UserRecord()
                                        {
                                            Weight = e.Peso,
                                            Heigth = e.Estatura,
                                            Date = e.Fecha,
                                            NutritionalStatus = e.EstadoNutricional
                                        });
                }
                else
                {
                    datas = query.Select(e => new UserRecord()
                                        {
                                            Weight = e.Peso,
                                            Heigth = e.Estatura,
                                            Date = e.Fecha,
                                            NutritionalStatus = e.EstadoNutricional
                                        });
                }
            }
            if (datas.Count() > 0)
            {
                return APIFunctions.SuccessResult(datas, JsonMessage.Success);
            }
            return APIFunctions.ErrorResult(string.Format(JsonMessage.NotFound, "Reportes"));
        }

    }
}