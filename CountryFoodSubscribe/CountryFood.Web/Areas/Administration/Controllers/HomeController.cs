namespace CountryFood.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using CountryFood.Data;
    using CountryFood.Web.Areas.Administration.Controllers.Base;

    public class HomeController : AdminController
    {
        public HomeController(IApplicationData data)
            : base(data)
        {
        }

        // GET: Administration/Home
        [HttpGet]
        public ActionResult Index()
        {
            return this.View(DateTime.Now);
        }

        [HttpPost]
        public ActionResult Index(DateTime datePicker)
        {
            return this.RedirectToAction("Index");
        }
    }
}