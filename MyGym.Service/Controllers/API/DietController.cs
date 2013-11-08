using MyGym.Common;
using MyGym.Data;
using MyGym.Service.Controllers.API.ErrorHandler;
using MyGym.Service.Models;
using MyGym.Service.Models.APIHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MyGym.Service.Controllers.API
{
    public class DietController : Controller
    {
        [HttpGet]
        [APIErrorHandler]
        public JsonResult Get(int userid, string day)
        {
            var result = new DietRepository().GetUserDiet(userid, day);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [APIErrorHandler]
        public JsonResult GenerateDiet(int userid, string userdatas)
        {
            var user = JsonConvert.DeserializeObject<UserInformation>(userdatas);
            var result = new DietRepository().GenerateDiet(userid, user);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
