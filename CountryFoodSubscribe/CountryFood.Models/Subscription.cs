namespace CountryFood.Models
{
    using System;
    using System.Collections.Generic;
    
    using CountryFood.Data.Common;
        
    public class Subscription : DeletableEntity
    {
        public int ID { get; set; }

        public string UserID { get; set; }

        public virtual AppUser User { get; set; }

        public int ProductID { get; set; }

        public virtual Product Product { get; set; }

        public SubscriptionState State { get; set; }

        public DateTime PeriodStart { get; set; }

        public DateTime PeriodEnd { get; set; }

        public Frequency Frequency { get; set; }

        public string Address { get; set; }
    }
}
