namespace Net3.Frontend.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Net3.Frontend.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Net3.Frontend.Logic;
    using System.Web.Razor.Generator;
    using Net3.Frontend.Logic.Interfaces;
    using Net3.Frontend.DataObjects.Models;
    using System.Security.Cryptography;

    internal sealed class Configuration : DbMigrationsConfiguration<Net3.Frontend.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Net3.Frontend.Models.ApplicationDbContext";
        }

        protected override void Seed(Net3.Frontend.Models.ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            IUserManager dbUserManager = new Logic.Classes.UserManager();
            
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("admin"))
            {
                var role = new IdentityRole();
                role.Name = "admin";
                roleManager.Create(role);
            }


            if (!context.Users.Any(u => u.UserName == "admin@chatdb.com"))
            {
                var user = new ApplicationUser()
                {
                    UserName = "admin@chatdb.com",
                    Email = "admin@chatdb.com"
                };

                IdentityResult result = userManager.Create(user, "P@ssw0rd");

                ApplicationUser appuser = userManager.FindByName(user.UserName);
                userManager.AddToRole(appuser.Id, "admin");
                UserModel dbUser = new UserModel
                {
                    UserId = "admin@chatdb.com",
                    PasswordHash = Logic.Classes.HelpManager.HashSha256("P@ssw0rd")
                };
                context.SaveChanges();
                dbUserManager.UserSignup(dbUser);
            }


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
