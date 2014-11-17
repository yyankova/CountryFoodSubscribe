namespace CountryFood.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CountryFood.Models;
    using CountryFood.Web.Infrastructure.Mappings;

    public class SubscriptionShortViewModel : IMapFrom<Subscription>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Subscription, SubscriptionShortViewModel>()
                .ForMember(
                m => m.Title,
                    options => options.MapFrom(m => m.Product.Name + " by " + m.Product.Producer.Name));
        }
    }
}