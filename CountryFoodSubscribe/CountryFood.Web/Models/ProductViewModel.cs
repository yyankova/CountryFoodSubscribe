using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountryFood.Web.Models
{
    public class ProductViewModel
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public string ProducerName { get; set; }

        public int VotesBalance { get; set; }
    }
}