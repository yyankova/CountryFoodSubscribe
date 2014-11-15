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

    public class ProducersManagerController : AdminController
    {
        public ProducersManagerController(IApplicationData data)
            : base(data)
        {
        }

        public ActionResult ReadProducers()
        {
            var producers = this.Data.Producers
                .All()
                .Project()
                .To<ProducerShortViewModel>()
                .ToList();

            return this.Json(producers, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return null;
        }

        [HttpPost]
        public ActionResult Create(ProducerInputModel model)
        {
            return null;
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return null;
        }

        [HttpPost]
        public ActionResult Delete(ProducerInputModel model)
        {
            return null;
        }

        [HttpGet]
        public ActionResult Update()
        {
            return null;
        }

        [HttpPost]
        public ActionResult Update(ProducerInputModel model)
        {
            return null;
        }
    }
}