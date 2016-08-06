using System.Web;
using BeeBack.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BeeBack.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BeeBack.Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BeeBack.Web.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var user = new ApplicationUser
            {
                UserName = "mv@live.be",
                Email = "mv@live.be",
                PhoneNumber = "+++++++",
                Firstname = "Matthieu",
                Lastname = "Vandenhende"
            };

            var user2 = new ApplicationUser()
            {
                UserName = "renaud@sparkle.tech",
                Email = "renaud@sparkle.tech",
                PhoneNumber = "++++++",
                Firstname = "Renaud",
                Lastname = "Dumont"
            };

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var result = userManager.Create(user, "test123");
            var result2 = userManager.Create(user2, "test123");
        }
    }
}
