namespace CountryFood.Data
{
    using CountryFood.Data.Common;
    using CountryFood.Models;

    public interface IApplicationData
    {
        IRepository<AppUser> Users { get; }

        IRepository<Region> Regions { get; }

        IRepository<Village> Villages { get; }

        IRepository<ProductCategory> Categories { get; }

        IRepository<Producer> Producers { get; }

        IRepository<Product> Products { get; }

        IRepository<Vote> Votes { get; }

        void SaveChanges();
    }
}
