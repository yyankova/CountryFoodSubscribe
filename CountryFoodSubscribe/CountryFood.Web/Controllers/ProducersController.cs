namespace CountryFood.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class ProducersController : Controller
    {
        // GET: Producers
        public ActionResult Display(int? id, int? page = 1)
        {
            if (id == null)
            {
                this.TempData["errorMessage"] = "No such id of product!";
                return this.RedirectToAction("Index", "Home");
            }

            return this.View();
        }
    }
}