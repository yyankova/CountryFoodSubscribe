namespace CountryFood.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using CountryFood.Models;
    using CountryFood.Web.Infrastructure.Mappings;

    public class ProductViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public string Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [UIHint("Category")]
        public string Category { get; set; }

        [Required]
        [UIHint("Producer")]
        public string Producer { get; set; }

        public string NumberOfSubscriptions { get; set; }

        public string PositiveVotes { get; set; }

        public string NegativeVotes { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Product, ProductViewModel>()
                .ForMember(m => m.Category, options => options.MapFrom(m => m.Category.Name));
            configuration.CreateMap<Product, ProductViewModel>()
                .ForMember(m => m.Producer, options => options.MapFrom(m => m.Producer.Name));
            
            configuration.CreateMap<Product, ProductViewModel>()
                .ForMember(m => m.Id, options => options.MapFrom(x => x.ID.ToString()));
            configuration.CreateMap<Product, ProductViewModel>()
                .ForMember(m => m.NumberOfSubscriptions, options => options.MapFrom(x => x.Subscriptions.AsEnumerable().Count().ToString()));
            configuration.CreateMap<Product, ProductViewModel>()
                .ForMember(m => m.NegativeVotes, options => options.MapFrom(x => x.Votes.AsEnumerable().Where(v => v.Value < 0).Count().ToString()));
            configuration.CreateMap<Product, ProductViewModel>()
                .ForMember(m => m.PositiveVotes, options => options.MapFrom(x => x.Votes.AsEnumerable().Where(v => v.Value > 0).Count().ToString()));
        }
    }
}