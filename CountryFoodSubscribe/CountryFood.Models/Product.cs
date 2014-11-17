namespace CountryFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CountryFood.Data.Common;

    public class Product : DeletableEntity
    {
        public Product()
        {
            this.Subscriptions = new HashSet<Subscription>();
            this.Votes = new HashSet<Vote>();
        }

        public int ID { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int CategoryID { get; set; }

        public virtual ProductCategory Category { get; set; }

        [Required]
        public int ProducerID { get; set; }

        public virtual Producer Producer { get; set; }

        public virtual ICollection<Subscription> Subscriptions { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
