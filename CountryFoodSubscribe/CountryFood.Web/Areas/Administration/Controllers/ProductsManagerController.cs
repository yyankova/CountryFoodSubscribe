namespace CountryFood.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using CountryFood.Data;
    using CountryFood.Models;
    using CountryFood.Web.Areas.Administration.Controllers.Base;
    using CountryFood.Web.InputModels;
    using CountryFood.Web.ViewModels;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    public class ProductsManagerController : AdminController
    {
        public ProductsManagerController(IApplicationData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult GetProducts([DataSourceRequest]DataSourceRequest request)
        {
            var products = this.Data
                .Products
                .All()
                .ToDataSourceResult(
                request,
                p => new ProductViewModel()
                {
                    Id = p.ID.ToString(),
                    Category = p.Category.Name,
                    Name = p.Name,
                    NegativeVotes = p.Votes.Where(v => v.Value < 0).Count().ToString(),
                    PositiveVotes = p.Votes.Where(v => v.Value > 0).Count().ToString(),
                    NumberOfSubscriptions = p.Subscriptions.Count().ToString(),
                    Producer = p.Producer.Name
                });

            return this.Json(products);
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, ProductViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var categoryId = int.Parse(model.Category);
                var producerId = int.Parse(model.Producer);
                var dbProduct = new Product()
                {
                    Name = model.Name,
                    CategoryID = categoryId,
                    ProducerID = producerId
                };

                this.Data.Products.Add(dbProduct);
                this.Data.SaveChanges();
                AutoMapper.Mapper.Map<Product, ProductViewModel>(dbProduct, model);
                return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
            }

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