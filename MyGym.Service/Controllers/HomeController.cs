using MyGym.Data;
using MyGym.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyGym.Common;
using Newtonsoft.Json;
using MyGym.Service.Models.APIHelper;
namespace MyGym.Service.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult API()
        {
            var api = new APIHelperRepository().GetAll();
            return View(api);
        }
        [HttpGet]
        public ActionResult GetAPI(int id)
        {
            var apiobject = new APIHelperRepository().Get(id);
            return View(apiobject);
        }
    }
}
