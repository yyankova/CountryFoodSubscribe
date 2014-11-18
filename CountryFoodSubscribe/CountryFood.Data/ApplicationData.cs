namespace CountryFood.Data
{
    using System;
    using System.Collections.Generic;

    using CountryFood.Data.Common;
    using CountryFood.Models;
 
    public class ApplicationData : IApplicationData
    {
        private IApplicationDbContext context;
        private IDictionary<Type, object> repositories;

        public ApplicationData(IApplicationDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IDeletableEntityRepository<AppUser> Users
        {
            get
            {
                return this.GetRepository<AppUser>();
            }
        }

        public IDeletableEntityRepository<Region> Regions
        {
            get
            {
                return this.GetRepository<Region>();
            }
        }

        public IDeletableEntityRepository<Village> Villages
        {
            get
            {
                return this.GetRepository<Village>();
            }
        }

        public IDeletableEntityRepository<ProductCategory> Categories
        {
            get
            {
                return this.GetRepository<ProductCategory>();
            }
        }

        public IDeletableEntityRepository<Producer> Producers
        {
            get
            {
                return this.GetRepository<Producer>();
            }
        }

        public IDeletableEntityRepository<Product> Products
        {
            get
            {
                return this.GetRepository<Product>();
            }
        }

        public IDeletableEntityRepository<Subscription> Subscriptions
        {
            get
            {
                return this.GetRepository<Subscription>();
            }
        }

        public IDeletableEntityRepository<Vote> Votes
        {
            get
            {
                return this.GetRepository<Vote>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IDeletableEntityRepository<T> GetRepository<T>() where T : class, IDeletableEntity
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeOfModel];
        }
    }
}
