using MyGym.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyGym.Service.Controllers
{
    public class RecomendationController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(MyGymContext.DB.Recomendacion.ToList());
        }
        [HttpDelete]
        public ActionResult Delete(int RecomendacionID)
        {
            return View();
        }
    }
}
