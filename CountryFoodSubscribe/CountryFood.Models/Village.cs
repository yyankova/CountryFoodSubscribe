namespace CountryFood.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Village
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
