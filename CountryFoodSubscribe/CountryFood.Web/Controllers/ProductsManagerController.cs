using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CountryFood.Web.Controllers
{
    public class ProductsManagerController : Controller
    {
        // GET: ProductsManager
        public ActionResult Index()
        {
            return View();
        }
    }
}