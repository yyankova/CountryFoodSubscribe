namespace CountryFood.Web.ViewModels
{
    using System.Linq;

    using CountryFood.Models;
    using CountryFood.Web.Infrastructure.Mappings;

    public class ProductViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public string ProducerName { get; set; }

        public int NumberOfSubscriptions { get; set; }

        public int PositiveVotes { get; set; }

        public int NegativeVotes { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Product, ProductViewModel>()
                .ForMember(m => m.Category, options => options.MapFrom(m => m.Category.Name));
            configuration.CreateMap<Product, ProductViewModel>()
                .ForMember(m => m.ProducerName, options => options.MapFrom(m => m.Producer.Name));
            
            configuration.CreateMap<Product, ProductViewModel>()
                .ForMember(m => m.NumberOfSubscriptions, options => options.MapFrom(x => x.Subscriptions.AsEnumerable().Count()));
            configuration.CreateMap<Product, ProductViewModel>()
                .ForMember(m => m.NegativeVotes, options => options.MapFrom(x => x.Votes.AsEnumerable().Where(v => v.Value < 0).Count()));
            configuration.CreateMap<Product, ProductViewModel>()
                .ForMember(m => m.PositiveVotes, options => options.MapFrom(x => x.Votes.AsEnumerable().Where(v => v.Value > 0).Count()));
        }
    }
}