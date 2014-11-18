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
                var category = this.Data
                    .Categories
                    .All()
                    .FirstOrDefault(c => c.ID == categoryId);
                if (category == null)
                {
                    this.TempData["errorMessage"] = "Category is not valid!";
                    return null;
                }

                var producer = this.Data
                    .Producers
                    .All()
                    .FirstOrDefault(p => p.ID == producerId);
                if (producer == null)
                {
                    this.TempData["errorMessage"] = "Producer is not valid!";
                    return null;
                }

                var dbProduct = new Product()
                {
                    Name = model.Name,
                    Category = category,
                    Producer = producer
                };

                this.Data.Products.Add(dbProduct);
                this.Data.SaveChanges();
                model.Category = category.Name;
                model.Producer = producer.Name;
                return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
            }
            
            return null;
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ProductViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var dbModel = this.Data
                    .Products
                    .All()
                    .FirstOrDefault(p => p.ID.ToString() == model.Id);
                if (dbModel != null)
                {
                    dbModel.Name = model.Name;
                    dbModel.CategoryID = int.Parse(model.Category);
                    dbModel.ProducerID = int.Parse(model.Producer);
                    this.Data.SaveChanges();

                    model.Category = dbModel.Category.Name;
                    model.Producer = dbModel.Producer.Name;
                };
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ProductViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var dbModel = this.Data.Products.GetById(int.Parse(model.Id));
                this.Data.Products.Delete(dbModel);
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}