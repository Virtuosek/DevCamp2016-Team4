using BeeBack.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace BeeBack.Web.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.UserActivities)
                .WithRequired(a => a.User)
                .HasForeignKey(a => a.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Activity>()
                .HasMany(a => a.UserActivities)
                .WithRequired(a => a.Activity)
                .HasForeignKey(a => a.ActivityID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(a => a.Activities)
                .WithRequired(a => a.User)
                .HasForeignKey(a => a.UserId)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<UserActivity> UserActivity { get; set; }

        public System.Data.Entity.DbSet<BeeBack.Web.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}