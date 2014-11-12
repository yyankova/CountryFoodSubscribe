using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CountryFood.Web.Controllers
{
    public class SubscriptionsController : Controller
    {
        // GET: Subscriptions
        public ActionResult Index()
        {
            return View();
        }
    }
}