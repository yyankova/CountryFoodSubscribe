namespace CountryFood.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CountryFood.Data.Common;

    public class ProductCategory : DeletableEntity
    {
        public ProductCategory()
        {
            this.Products = new HashSet<Product>();
        }

        public int ID { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
