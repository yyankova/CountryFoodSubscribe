namespace CountryFood.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;

    using CountryFood.Data;
    using CountryFood.Web.Areas.Administration.Controllers.Base;
    using CountryFood.Web.InputModels;
    using CountryFood.Web.ViewModels;
    using CountryFood.Models;

    public class ProductsManagerController : AdminController
    {
        public ProductsManagerController(IApplicationData data) : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        //GetProducts
        [HttpPost]
        public ActionResult GetProducts([DataSourceRequest]DataSourceRequest request)
        {
            var products =
                this.Data
                .Products
                .All()
                .ToDataSourceResult(request, p => new ProductViewModel()
                {
                    Id = p.ID.ToString(),
                    Category = p.Category.Name,
                    Name = p.Name,
                    NegativeVotes = p.Votes.Where(v => v.Value < 0).Count().ToString(),
                    PositiveVotes = p.Votes.Where(v => v.Value > 0).Count().ToString(),
                    NumberOfSubscriptions = p.Subscriptions.Count().ToString(),
                    ProducerName = p.Producer.Name
                });

            return this.Json(products);
        }




        [HttpGet]
        public ActionResult Create()
        {
            return null;
        }

        [HttpPost]
        public ActionResult Create(ProductInputModel model)
        {
            return null;
        }
        
        [HttpGet]
        public ActionResult Delete()
        {
            return null;
        }

        [HttpPost]
        public ActionResult Delete(SubscriptionInputModel model)
        {
            return null;
        }

        [HttpGet]
        public ActionResult Update()
        {
            return null;
        }

        [HttpPost]
        public ActionResult Update(ProductInputModel model)
        {
            return null;
        }
    }
}