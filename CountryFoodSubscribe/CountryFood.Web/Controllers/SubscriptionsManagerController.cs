using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CountryFood.Web.Controllers
{
    public class SubscriptionsManagerController : Controller
    {
        public ActionResult List()
        {
            // Add filter by subscription state
            return View();
        }

        [HttpGet]
        public ActionResult Approve()
        {
            return null;
        }

        [HttpPost]
        public ActionResult Approve()
        {
            return null;
        }

        [HttpGet]
        public ActionResult Drop()
        {
            return null;
        }

        [HttpPost]
        public ActionResult Drop()
        {
            return null;
        }
    }
}