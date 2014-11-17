namespace CountryFood.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    
    using CountryFood.Web.InputModels;

    public class SubscriptionsManagerController : Controller
    {
        public ActionResult List()
        {
            // Add filter by subscription state
            return this.View();
        }

        [HttpGet]
        public ActionResult Approve()
        {
            return null;
        }

        [HttpPost]
        public ActionResult Approve(SubscriptionInputModel model)
        {
            return null;
        }

        [HttpGet]
        public ActionResult Drop()
        {
            return null;
        }

        [HttpPost]
        public ActionResult Drop(SubscriptionInputModel model)
        {
            return null;
        }
    }
}