namespace CountryFood.Web.ViewModels
{
    using CountryFood.Models;
    using CountryFood.Web.Infrastructure.Mappings;

    public class ProducerViewModel : IMapFrom<Producer>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Picture { get; set; }

        public string Description { get; set; }

        public string Village { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Producer, ProducerViewModel>()
                .ForMember(m => m.Village, 
                    options => options.MapFrom(m => m.Village.Name));
        }
    }
}