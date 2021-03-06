﻿namespace CountryFood.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using CountryFood.Data.Common;
    using CountryFood.Data.Migrations;
    using CountryFood.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    
    public class ApplicationDbContext : IdentityDbContext<AppUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public virtual IDbSet<Region> Regions { get; set; }

        public virtual IDbSet<Village> Villages { get; set; }

        public virtual IDbSet<ProductCategory> Categories { get; set; }

        public virtual IDbSet<Producer> Producers { get; set; }

        public virtual IDbSet<Product> Products { get; set; }

        public virtual IDbSet<Subscription> Subscriptions { get; set; }

        public virtual IDbSet<Vote> Votes { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
