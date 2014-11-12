namespace CountryFood.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using CountryFood.Data;
    using CountryFood.Web.Models;

    public class HomeController : Controller
    {
        private IApplicationData data;

        public HomeController(IApplicationData data)
        {
            this.data = data;
        }

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult GetProducts()
        {
            var products = this.data.Products
                .All()
                .Select(p => new ProductViewModel() { Name = p.Name })
                .ToList();
            return PartialView("~/Views/Shared/_ProductsPartial.cshtml", products);
        }

        [ChildActionOnly]
        public ActionResult GetProducers()
        {
            var producers = this.data.Producers
                .All()
                .Select(p => new ProducerViewModel() { Name = p.Name })
                .ToList();
            return PartialView("~/Views/Shared/_ProducersPartial.cshtml", producers);
        }
    }
}