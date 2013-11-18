using MyGym.Service.Controllers.API.ErrorHandler;
using MyGym.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyGym.Service.Controllers.API
{
    public class ExerciseController : Controller
    {
        [HttpGet]
        [APIErrorHandler]
        public JsonResult Get(int exerciseID)
        {
            var result = new ExerciseRepository().Get(exerciseID);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
