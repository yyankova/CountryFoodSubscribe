using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CountryFood.Web.Controllers
{
    public class ProducersController : Controller
    {
        // GET: Producers
        public ActionResult Display(int? id)
        {
            if (id == null)
            {
                TempData["errorMessage"] = "No such id of product!";
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}