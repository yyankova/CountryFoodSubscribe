namespace CountryFood.Models
{
    using System;
    using System.Collections.Generic;

    using CountryFood.Data.Common;

    public class Producer : DeletableEntity
    {
        public Producer()
        {
            this.Products = new HashSet<Product>();
        }

        public int ID { get; set; }

        public string Name { get; set; }

        // TODO: List of pictures
        public byte[] Picture { get; set; }

        public string Description { get; set; }

        public int VillageID { get; set; }

        public virtual Village Village { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
