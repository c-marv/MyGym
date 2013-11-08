using MyGym.Common;
using MyGym.Data;
using MyGym.Data.Entities;
using MyGym.Service.Controllers.API.ErrorHandler;
using MyGym.Service.Models;
using MyGym.Service.Models.APIHelper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MyGym.Service.Controllers.API
{
    public class UserController : Controller
    {
        [HttpGet]
        [APIErrorHandler]
        public JsonResult Get(int userid)
        {
            var result = new UserRepository().Get(userid);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [APIErrorHandler]
        public JsonResult Register(string userdata)
        {
            var result = new UserRepository().Add(JsonConvert.DeserializeObject<UserInformation>(userdata));
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [APIErrorHandler]
        public JsonResult Update(string userdata)
        {
            var result = (new UserRepository()).Update(JsonConvert.DeserializeObject<UserInformation>(userdata));
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        [APIErrorHandler]
        public JsonResult Delete(int userid)
        {
            var result = (new UserRepository()).Delete(userid);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [APIErrorHandler]
        public JsonResult LogIn(string logindata)
        {
            JObject login = (JObject)JsonConvert.DeserializeObject(logindata);
            if (login["user"] != null & login["password"] != null)
            {
                var result = (new UserRepository()).LogIn(login["user"].ToString(), login["pasword"].ToString());
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return Json(APIFunctions.ErrorResult(JsonMessage.BadRequest), JsonRequestBehavior.AllowGet);
        }
    }
}
