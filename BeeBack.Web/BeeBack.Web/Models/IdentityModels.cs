using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace BeeBack.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        /// <summary>
        /// Activities to which this user has subscribed
        /// </summary>
        public List<UserActivity> UserActivities { get; set; }

        /// <summary>
        /// Activities created by the user
        /// </summary>
        public List<Activity> Activities { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PictureUrl { get; set; }
    }

}