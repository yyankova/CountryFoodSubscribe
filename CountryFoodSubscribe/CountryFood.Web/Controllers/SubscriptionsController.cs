using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CountryFood.Web.Controllers
{
    public class SubscriptionsController : Controller
    {
        // Authenticated user
        public ActionResult List()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return null;
        }

        [HttpPost]
        public ActionResult Create()
        {
            return null;
        }

        [HttpGet]
        public ActionResult Cancel()
        {
            return null;
        }

        [HttpPost]
        public ActionResult Cancel()
        {
            return null;
        }
    }
}