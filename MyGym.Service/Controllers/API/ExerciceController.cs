using MyGym.Service.Controllers.API.ErrorHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using MyGym.Service.Models;

namespace MyGym.Service.Controllers.API
{
    public class ExcercieController : Controller
    {
        [HttpGet]
        [APIErrorHandler]
        public JsonResult Get(int userID, bool mode)
        {
            var result = new RoutineRepository().GenerateRoutine(userID, mode);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}

