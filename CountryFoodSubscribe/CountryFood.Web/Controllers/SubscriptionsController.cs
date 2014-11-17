namespace CountryFood.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using CountryFood.Data;
    using CountryFood.Models;
    using CountryFood.Web.InputModels;
    using CountryFood.Web.ViewModels;

    [Authorize]
    public class SubscriptionsController : BaseController
    {
        public SubscriptionsController(IApplicationData data)
            : base(data)
        {
        }

        //TODO: server side paging and sorting and filtering
        public ActionResult List(string sortProperty, string sortOrder = "asc", int page = 1)
        {
            var subscriptions = this.Data
                .Subscriptions
                .All()
                .Where(s => s.UserID == UserId)
                .Project()
                .To<SubscriptionShortViewModel>()
                .ToList();

            return View(subscriptions);
        }

        public ActionResult Details(int? id)
        {
            if (!Request.IsAjaxRequest())
            {
                Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return this.Content("This action can be invoke only by AJAX call");
            }

            if (id == null)
            {
                TempData["errorMessage"] = "No subscription id!";
                return RedirectToAction("List");
            }

            var subscription = this.Data
                .Subscriptions
                .All()
                .Where(s => s.ID == id)
                .FirstOrDefault();
            if (subscription == null)
            {
                TempData["errorMessage"] = String.Format("No subscription with id {0}", id);
                return RedirectToAction("List");
            }

            if (subscription.UserID != UserId)
            {
                TempData["errorMessage"] = String.Format("Subscription with id {0} is not for current user!", id);
                return RedirectToAction("List");
            }

            var viewSubscriptionList = new List<Subscription> { subscription };
            var viewSubscription = viewSubscriptionList
                .AsQueryable()
                .Project()
                .To<SubscriptionViewModel>()
                .FirstOrDefault();

            return PartialView("_SubscriptionDetailsPartial", viewSubscription);
        }

        [HttpGet]
        public ActionResult Create(int? productId)
        {
            if (productId == null)
            {
                this.TempData["errorMessage"] = "No product selected";
                return this.RedirectToAction("Index", "Products", null);
            }

            var subscription = new SubscriptionInputModel()
            {
                ProductID = (int)productId,
                PeriodStart = DateTime.Now,
                PeriodEnd = DateTime.Now,
                Frequency = CountryFood.Models.Frequency.Yearly
            };

            return this.View(subscription);
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

            this.TempData["successMessage"] = "Subscription successfully created!";
            return this.RedirectToAction("List");
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