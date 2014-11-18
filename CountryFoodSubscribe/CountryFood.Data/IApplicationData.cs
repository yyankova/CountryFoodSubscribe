namespace CountryFood.Data
{
    using CountryFood.Data.Common;
    using CountryFood.Models;

    public interface IApplicationData
    {
        IDeletableEntityRepository<AppUser> Users { get; }

        IDeletableEntityRepository<Region> Regions { get; }

        IDeletableEntityRepository<Village> Villages { get; }

        IDeletableEntityRepository<ProductCategory> Categories { get; }

        IDeletableEntityRepository<Producer> Producers { get; }

        IDeletableEntityRepository<Product> Products { get; }

        IDeletableEntityRepository<Subscription> Subscriptions { get; }

        IDeletableEntityRepository<Vote> Votes { get; }

        void SaveChanges();
    }
}
