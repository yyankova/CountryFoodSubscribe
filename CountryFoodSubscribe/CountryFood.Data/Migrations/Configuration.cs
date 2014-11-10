namespace CountryFood.Data.Migrations
{
    using CountryFood.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
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
        }

        private void SeedUsers(ApplicationDbContext context)
        {
            var UserManager = new UserManager<AppUser>(new UserStore<AppUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            string adminRole = "admin";
            string appUserRole = "appUser";
            string password = "123456";

            //Create Role Test and User Test
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

            base.Seed(context);
        }
    }
}
