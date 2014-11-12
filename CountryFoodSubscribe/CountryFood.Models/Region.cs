namespace CountryFood.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CountryFood.Data.Common;

    public class Region : DeletableEntity
    {
        public Region()
        {
            this.Villages = new HashSet<Village>();
        }

        public int ID { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Village> Villages { get; set; }
    }
}
