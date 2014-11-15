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


    public class CategoriesController : AdminController
    {
        public CategoriesController(IApplicationData data)
            : base(data)
        {
        }

        public ActionResult ReadCategories()
        {
            var producers = this.Data.Categories
                .All()
                .Project()
                .To<CategoryViewModel>()
                .ToList();

            return this.Json(producers, JsonRequestBehavior.AllowGet);
        }
    }
}