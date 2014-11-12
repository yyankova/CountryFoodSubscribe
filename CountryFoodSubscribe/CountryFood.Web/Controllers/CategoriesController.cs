using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CountryFood.Web.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult GetProductsFromCategory(string category)
        {
            return View();
        }
    }
}