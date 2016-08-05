using BeeBack.Data.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BeeBack.Data
{
    public class BeeBackContext : DbContext
    {
        private const string _lol = @"Server=tcp:beebackpoc.database.windows.net,1433;Initial Catalog=BeeBack_POC;Persist Security Info=False;User ID=beeback;Password=SuperPassw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public BeeBackContext() : base(_lol)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<UserActivity> UserActivity { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
