using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountryFood.Web.Models
{
    public class ProducerViewModel
    {
        public string Name { get; set; }

        public byte[] Picture { get; set; }

        public string Description { get; set; }

        public string Village { get; set; }
    }
}