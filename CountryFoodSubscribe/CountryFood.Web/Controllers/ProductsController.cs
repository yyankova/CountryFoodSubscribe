namespace CountryFood.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Vote()
        {
            return null;
        }
    }
}