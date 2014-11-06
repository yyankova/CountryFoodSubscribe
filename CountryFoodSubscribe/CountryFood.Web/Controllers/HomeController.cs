using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CountryFood.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //return Redirect("http://google.bg");
            string message = (string)ViewBag.Message;
            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";
            TempData["message"] = "My message here";
            return RedirectToAction("Index");
            //return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}