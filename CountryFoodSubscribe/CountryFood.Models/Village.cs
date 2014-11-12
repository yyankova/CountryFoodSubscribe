namespace CountryFood.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CountryFood.Data.Common;

    public class Village : DeletableEntity
    {
        public Village()
        {
            this.Producers = new HashSet<Producer>();
        }

        public int ID { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int RegionID { get; set; }

        public virtual Region Region { get; set; }

        public virtual ICollection<Producer> Producers { get; set; }
    }
}
