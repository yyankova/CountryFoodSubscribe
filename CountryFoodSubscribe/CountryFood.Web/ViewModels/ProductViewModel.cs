namespace CountryFood.Web.ViewModels
{
    using CountryFood.Models;
    using CountryFood.Web.Infrastructure.Mappings;

    public class ProductViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public string ProducerName { get; set; }

        //public int VotesBalance { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Product, ProductViewModel>()
                .ForMember(m => m.Category, options => options.MapFrom(m => m.Category.Name));
            configuration.CreateMap<Product, ProductViewModel>()
                .ForMember(m => m.ProducerName, options => options.MapFrom(m => m.Producer.Name));
            //configuration.CreateMap<Product, ProductViewModel>()
            //    .ForMember(m => m.VotesBalance, options => options.MapFrom(m => m.Category.Name));
        }
    }
}