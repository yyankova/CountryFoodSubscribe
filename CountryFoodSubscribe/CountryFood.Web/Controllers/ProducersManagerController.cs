using CountryFood.Web.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CountryFood.Web.Controllers
{
    public class ProducersManagerController : Controller
    {
        // GET: ProducersManager
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