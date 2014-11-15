using CountryFood.Web.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CountryFood.Web.Areas.Administration.Controllers
{
    public class ProductsManagerController : Controller
    {
        // GET: ProductsManager
        public ActionResult Index()
        {
            return View();
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