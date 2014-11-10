namespace CountryFood.Data.Migrations
{
    using CountryFood.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (context.Roles.Count() == 0)
            {
                this.SeedUsers(context);
            }

            if (context.Regions.Count() == 0)
            {
                this.SeedRegions(context);
            }

            if (context.Categories.Count() == 0)
            {
                this.SeedCategories(context);
            }

            if (context.Villages.Count() == 0)
            {
                this.SeedVillages(context);
            }


            base.Seed(context);
        }

        private void SeedUsers(ApplicationDbContext context)
        {
            var UserManager = new UserManager<AppUser>(new UserStore<AppUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            string adminRole = "admin";
            string appUserRole = "appUser";
            string password = "123456";

            //Create Role appUser and 2 users
            RoleManager.Create(new IdentityRole(appUserRole));
            UserManager.Create(new AppUser()
            {
                UserName = "user1@test.com",
                Email = "user1@test.com"
            }, password);
            UserManager.Create(new AppUser()
            {
                UserName = "user2@test.com",
                Email = "user2@test.com"
            }, password);

            //Create Role Admin if it does not exist
            if (!RoleManager.RoleExists(adminRole))
            {
                var roleresult = RoleManager.Create(new IdentityRole(adminRole));
            }

            //Create User=Admin with password=123456
            var adminUser = new AppUser();
            adminUser.UserName = "admin1@test.com";
            adminUser.Email = "admin1@test.com";
            var adminresult = UserManager.Create(adminUser, password);

            //Add User Admin to Role Admin
            if (adminresult.Succeeded)
            {
                var result = UserManager.AddToRole(adminUser.Id, adminRole);
            }
        }

        private void SeedRegions(ApplicationDbContext context)
        {
            var regions = new List<Region>()
            {
                new Region() { Name = "North-West"},
                new Region() { Name = "North-Central"},
                new Region() { Name = "North-East"},
                new Region() { Name = "South-East"},
                new Region() { Name = "South-Central"},
                new Region() { Name = "South-West"},
            };

            foreach (var region in regions)
            {
                context.Regions.Add(region);
            }
        }

        private void SeedCategories(ApplicationDbContext context)
        {
            var categories = new List<ProductCategory>
            {
                new ProductCategory{ Name = "Milk"},
                new ProductCategory{ Name = "Vegetables"},
                new ProductCategory{ Name = "Fruit"},
                new ProductCategory{ Name = "Herbs"},
                new ProductCategory{ Name = "Cans"},
                new ProductCategory{ Name = "Dry fruits & veggies"},
            };

            foreach (var category in categories)
            {
                context.Categories.Add(category);
            }
        }

        private void SeedVillages(ApplicationDbContext context)
        {
            Random rand = new Random();
            var regionIds = context.Regions.Select(r => r.ID).ToList();
            int regionsCount = regionIds.Count();

            var villages = new List<Village>()
            {
                new Village { Name = "Buhovo", RegionID = regionIds.ElementAt(rand.Next(regionsCount))},
                new Village { Name = "Muhovo", RegionID = regionIds.ElementAt(rand.Next(regionsCount))},
                new Village { Name = "Elhovo", RegionID = regionIds.ElementAt(rand.Next(regionsCount))},
                new Village { Name = "Gorni Lozen", RegionID = regionIds.ElementAt(rand.Next(regionsCount))},
                new Village { Name = "Dolni Lozen", RegionID = regionIds.ElementAt(rand.Next(regionsCount))},
                new Village { Name = "Brulino", RegionID = regionIds.ElementAt(rand.Next(regionsCount))},
            };

            foreach (var village in villages)
            {
                context.Villages.Add(village);
            }
        }
    }
}
