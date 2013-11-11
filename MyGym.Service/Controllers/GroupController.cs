using MyGym.Data.Entities;
using MyGym.Service.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyGym.Service.Controllers
{
    public class GroupController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var result = new GroupRepository().GetAll();
            return View(result);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Create(string groupdata)
        {
            Grupo group = JsonConvert.DeserializeObject<Grupo>(groupdata);
            string redirect = new UrlHelper(Request.RequestContext).Action("Index");
            int result = new GroupRepository().Add(group);
            if (result == 0)
            {
                redirect = new UrlHelper(Request.RequestContext).Action("Create");
            }
            return Json(new { Url = redirect });
        }
        [HttpGet]
        public ActionResult Delete(int groupid)
        {
            new GroupRepository().Delete(groupid);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int groupid)
        {
            var result = new GroupRepository().Get(groupid);
            return View(result);
        }
        [HttpPost]
        public JsonResult Edit(int groupid, string groupdata)
        {
            Grupo group = JsonConvert.DeserializeObject<Grupo>(groupdata);
            new GroupRepository().Update(groupid, group);
            string redirect = new UrlHelper(Request.RequestContext).Action("Index");
            return Json(new { Url = redirect });
        }
    }
}
