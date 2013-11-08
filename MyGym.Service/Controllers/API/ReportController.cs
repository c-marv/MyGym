using MyGym.Service.Controllers.API.ErrorHandler;
using MyGym.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyGym.Service.Controllers.API
{
    public class ReportController : Controller
    {
        [HttpGet]
        [APIErrorHandler]
        public JsonResult Get(int userid, string filter = "month", int weeks = 0)
        {
            var result = new ReportRepository().GetUserRecord(userid, filter, weeks);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
