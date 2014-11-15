namespace CountryFood.Web.ViewModels
{
    using System;
    using System.Collections.Generic;

    using CountryFood.Models;
    using CountryFood.Web.Infrastructure.Mappings;
    using System.ComponentModel.DataAnnotations;

    public class SubscriptionViewModel : IMapFrom<Subscription>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Product { get; set; }

        [Display(Name = "State")]
        public SubscriptionState State { get; set; }

        [Display(Name = "Delivery Start")]
        public DateTime PeriodStart { get; set; }

        [Display(Name = "Delivery End")]
        public DateTime PeriodEnd { get; set; }

        public Frequency Frequency { get; set; }

        public string Address { get; set; }

        public string Producer { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Subscription, SubscriptionViewModel>()
                .ForMember(m => m.Product,
                    options => options.MapFrom(m => m.Product.Name));

            configuration.CreateMap<Subscription, SubscriptionViewModel>()
                .ForMember(m => m.Producer,
                    options => options.MapFrom(m => m.Product.Producer.Name));

            configuration.CreateMap<Subscription, SubscriptionViewModel>()
                .ForMember(m => m.Title,
                    options => options.MapFrom(m => m.Product.Name + " by " + m.Product.Producer.Name));
        }
    }
}