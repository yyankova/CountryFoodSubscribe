namespace CountryFood.Data
{
    using System;
    using System.Data.Entity;

    using CountryFood.Models;

    public interface IApplicationDbContext
    {
        IDbSet<ProductCategory> Categories { get; set; }

        IDbSet<Producer> Producers { get; set; }
        
        IDbSet<Product> Products { get; set; }
        
        IDbSet<Region> Regions { get; set; }
        
        IDbSet<Subscription> Subscriptions { get; set; }
        
        IDbSet<Village> Villages { get; set; }
        
        IDbSet<Vote> Votes { get; set; }
        
        IDbSet<T> Set<T>() where T : class;
        
        int SaveChanges();
    }
}
