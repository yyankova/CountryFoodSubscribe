namespace CountryFood.Web.InputModels
{
    using System;

    using CountryFood.Models;
    using System.ComponentModel.DataAnnotations;

    public class SubscriptionInputModel
    {
        [Required]
        public int ProductID { get; set; }

        [Required]
        [Display(Name = "Subscription start")]
        public DateTime PeriodStart { get; set; }

        [Required]
        [Display(Name = "Subscription end")]
        public DateTime PeriodEnd { get; set; }

        [Required]
        [Display(Name = "Frequency of delivery")]
        [DataType("CountryFood.Models.Frequency")]
        public Frequency Frequency { get; set; }

        [Required]
        [Display(Name = "Address for delivery")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
    }
}