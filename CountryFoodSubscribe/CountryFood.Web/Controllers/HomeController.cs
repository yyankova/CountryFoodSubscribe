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
    }
}