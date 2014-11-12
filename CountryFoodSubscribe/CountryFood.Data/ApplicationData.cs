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

        public IRepository<AppUser> Users
        {
            get
            {
                return this.GetRepository<AppUser>();
            }
        }

        public IRepository<Region> Regions
        {
            get
            {
                return this.GetRepository<Region>();
            }
        }

        public IRepository<Village> Villages
        {
            get
            {
                return this.GetRepository<Village>();
            }
        }

        public IRepository<ProductCategory> Categories
        {
            get
            {
                return this.GetRepository<ProductCategory>();
            }
        }

        public IRepository<Producer> Producers
        {
            get
            {
                return this.GetRepository<Producer>();
            }
        }

        public IRepository<Product> Products
        {
            get
            {
                return this.GetRepository<Product>();
            }
        }

        public IRepository<Subscription> Subscriptions
        {
            get
            {
                return this.GetRepository<Subscription>();
            }
        }

        public IRepository<Vote> Votes
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

        private IRepository<T> GetRepository<T>() where T : class, IDeletableEntity
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }
    }
}
