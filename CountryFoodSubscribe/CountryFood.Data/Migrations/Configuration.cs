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

            if (context.Producers.Count() == 0)
            {
                this.SeedProducers(context);
            }

            if (context.Products.Count() == 0)
            {
                this.SeedProducts(context);
            }

            if (context.Subscriptions.Count() == 0)
            {
                this.SeedSubscriptions(context);
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

        private void SeedProducers(ApplicationDbContext context)
        {
            Random rand = new Random();

            var villageIds = context.Villages.Select(v => v.ID).ToList();
            int villageCount = villageIds.Count;

            var producers = new List<Producer>
            {
                new Producer
                {
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc rhoncus orci vel sem ultricies, non iaculis augue vehicula. In venenatis ipsum nec elit accumsan, id aliquet est faucibus. Aenean ultrices ligula dolor, ac imperdiet sapien ornare et. Curabitur molestie molestie iaculis. Ut porttitor dictum venenatis. Vivamus posuere lacus commodo arcu imperdiet bibendum. Nunc at efficitur velit, at sollicitudin purus. Nunc sollicitudin consequat lorem, id rhoncus odio efficitur at.",
                    Name = "Green House",
                    VillageID = villageIds[rand.Next(villageCount)]
                },
                new Producer
                {
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc rhoncus orci vel sem ultricies, non iaculis augue vehicula. In venenatis ipsum nec elit accumsan, id aliquet est faucibus. Aenean ultrices ligula dolor, ac imperdiet sapien ornare et. Curabitur molestie molestie iaculis. Ut porttitor dictum venenatis. Vivamus posuere lacus commodo arcu imperdiet bibendum. Nunc at efficitur velit, at sollicitudin purus. Nunc sollicitudin consequat lorem, id rhoncus odio efficitur at.",
                    Name = "Green Gables",
                    VillageID = villageIds[rand.Next(villageCount)]
                },
                new Producer
                {
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc rhoncus orci vel sem ultricies, non iaculis augue vehicula. In venenatis ipsum nec elit accumsan, id aliquet est faucibus. Aenean ultrices ligula dolor, ac imperdiet sapien ornare et. Curabitur molestie molestie iaculis. Ut porttitor dictum venenatis. Vivamus posuere lacus commodo arcu imperdiet bibendum. Nunc at efficitur velit, at sollicitudin purus. Nunc sollicitudin consequat lorem, id rhoncus odio efficitur at.",
                    Name = "Blue Skies",
                    VillageID = villageIds[rand.Next(villageCount)]
                },
                new Producer
                {
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc rhoncus orci vel sem ultricies, non iaculis augue vehicula. In venenatis ipsum nec elit accumsan, id aliquet est faucibus. Aenean ultrices ligula dolor, ac imperdiet sapien ornare et. Curabitur molestie molestie iaculis. Ut porttitor dictum venenatis. Vivamus posuere lacus commodo arcu imperdiet bibendum. Nunc at efficitur velit, at sollicitudin purus. Nunc sollicitudin consequat lorem, id rhoncus odio efficitur at.",
                    Name = "Sun City",
                    VillageID = villageIds[rand.Next(villageCount)]
                },
            };

            foreach (var producer in producers)
            {
                context.Producers.Add(producer);
            }
        }

        private void SeedProducts(ApplicationDbContext context)
        {
            var milkCategory = context.Categories.Where(c => c.Name == "Milk").First();
            var herbsCategory = context.Categories.Where(c => c.Name == "Herbs").First();

            var producers = context.Producers.Select(p => p.ID).Take(2).ToList();
            var products = new List<Product>
            {
                new Product
                {
                    Category = milkCategory,
                    Name = "Goat cheeze",
                    ProducerID = producers[0]
                },
                new Product
                {
                    Category = herbsCategory,
                    Name = "Basil",
                    ProducerID = producers[0]
                },
                new Product
                {
                    Category = milkCategory,
                    Name = "Yogurt",
                    ProducerID = producers[1]
                },
                new Product
                {
                    Category = herbsCategory,
                    Name = "Mint",
                    ProducerID = producers[1]
                },
            };

            foreach (var product in products)
            {
                context.Products.Add(product);
            }
        }

        private void SeedSubscriptions(ApplicationDbContext context)
        {
            Random rand = new Random();
            var appUsers = context.Users.Where(u => u.Email == "user1@test.com" || u.Email == "user2@test.com").ToList();
            var products = context.Products.ToList();
            int productsCount = products.Count;

            var subscribtions = new List<Subscription>
            {
                new Subscription
                {
                    Address = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium",
                    Frequency = Frequency.BiWeekly,
                    PeriodEnd = new DateTime(2014, 12, 31),
                    PeriodStart = new DateTime(2014, 1, 1),
                    User = appUsers[0],
                    State = SubscriptionState.Current,
                    Product = products[rand.Next(productsCount)],
                },
                new Subscription
                {
                    Address = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium",
                    Frequency = Frequency.Monthly,
                    PeriodEnd = new DateTime(2014, 12, 31),
                    PeriodStart = new DateTime(2014, 1, 1),
                    User = appUsers[0],
                    State = SubscriptionState.Current,
                    Product = products[rand.Next(productsCount)],
                },
                new Subscription
                {
                    Address = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium",
                    Frequency = Frequency.Weekly,
                    PeriodEnd = new DateTime(2014, 12, 31),
                    PeriodStart = new DateTime(2014, 1, 1),
                    User = appUsers[1],
                    State = SubscriptionState.Waiting,
                    Product = products[rand.Next(productsCount)],
                },
                new Subscription
                {
                    Address = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium",
                    Frequency = Frequency.Yearly,
                    PeriodEnd = new DateTime(2014, 12, 31),
                    PeriodStart = new DateTime(2014, 1, 1),
                    User = appUsers[1],
                    State = SubscriptionState.Pending,
                    Product = products[rand.Next(productsCount)],
                },
            };
            foreach (var subscription in subscribtions)
            {
                context.Subscriptions.Add(subscription);
            }
        }
    }
}
