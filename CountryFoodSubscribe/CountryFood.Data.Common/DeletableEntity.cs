namespace CountryFood.Data.Common
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class DeletableEntity : AuditInfo, IDeletableEntity
    {
        [Display(Name = "Deleted?")]
        [Editable(false)]
        [Index]
        public bool IsDeleted { get; set; }

        [Display(Name = "Deletion date")]
        [Editable(false)]
        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }
    }
}
