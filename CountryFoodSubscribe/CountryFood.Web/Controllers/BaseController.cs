namespace CountryFood.Web.Controllers
{
    using CountryFood.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    public class BaseController : Controller
    {
        private IApplicationData data;

        public BaseController(IApplicationData data)
        {
            this.data = data;
        }

        protected IApplicationData Data
        {
            get
            {
                return this.data;
            }
        }

        protected string UserId
        {
            get
            {
                return User.Identity.GetUserId();
            }
        }
    }
}