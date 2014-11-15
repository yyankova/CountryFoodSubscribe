namespace CountryFood.Web.ViewModels
{
    using CountryFood.Models;
    using CountryFood.Web.Infrastructure.Mappings;

    public class CategoryViewModel : IMapFrom<ProductCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}