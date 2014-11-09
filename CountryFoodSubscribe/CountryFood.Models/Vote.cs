namespace CountryFood.Models
{
    using System;
    using System.Collections.Generic;

    using CountryFood.Data.Common;

    public class Vote : DeletableEntity
    {
        public int ID { get; set; }

        public int ProductID { get; set; }

        public virtual Product Product { get; set; }

        public string UserID { get; set; }

        public virtual AppUser User { get; set; }

        public int Value { get; set; }
    }
}
