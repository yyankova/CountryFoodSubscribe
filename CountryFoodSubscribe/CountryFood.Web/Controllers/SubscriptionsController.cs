namespace CountryFood.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using CountryFood.Data;
    using CountryFood.Models;
    using CountryFood.Web.InputModels;

    public class SubscriptionsController : BaseController
    {
        public SubscriptionsController(IApplicationData data) : base(data)
        {
        }

        // Authenticated user
        public ActionResult List()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create(int? productId)
        {
            if (productId == null)
            {
                TempData["errorMessage"] = "No product selected";
                return RedirectToAction("Index", "Products", null);
            }

            var subscription = new SubscriptionInputModel()
            {
                ProductID = (int)productId,
                PeriodStart = DateTime.Now,
                PeriodEnd = DateTime.Now,
                Frequency = CountryFood.Models.Frequency.Yearly
            };

            return View(subscription);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubscriptionInputModel model)
        {
            //TODO: date start and date end are hardcoded, uncomment the check after fix
            //if (!ModelState.IsValid)
            //{
            //    return View("Create", model);
            //}

            //if (model.PeriodStart >= model.PeriodEnd)
            //{
            //    ModelState.AddModelError("", "Delivery end date must be after delivery subscription date!");
            //    return View("Create", model);
            //}
            
            var subscription = new Subscription()
            {
                Address = model.Address,
                Frequency = model.Frequency,
                PeriodStart = DateTime.Now,
                PeriodEnd = DateTime.Now.AddYears(1),
                ProductID = model.ProductID,
                State = SubscriptionState.Pending,
                UserID = UserId,
            };

            this.Data.Subscriptions
                .Add(subscription);
            this.Data.SaveChanges();

            TempData["successMessage"] = "Subscription successfully created!";
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Cancel()
        {
            return null;
        }

        [HttpPost]
        public ActionResult Cancel(SubscriptionInputModel model)
        {
            return null;
        }
    }
}