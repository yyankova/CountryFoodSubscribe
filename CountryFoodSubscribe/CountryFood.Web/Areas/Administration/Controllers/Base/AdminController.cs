﻿namespace CountryFood.Web.Areas.Administration.Controllers.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using CountryFood.Data;
    using CountryFood.Web.Controllers;
    // [Authorize(Roles="Admin")]
    public class AdminController : BaseController
    {
        public AdminController(IApplicationData data) : base(data)
        {
        }
    }
}