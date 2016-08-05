using BeeBack.Data.Models;
using BeeBack.Web.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace BeeBack.Web.Controllers.Api
{
    public class ActivitiesController : BaseApiController
    {
        /// <summary>
        /// Return all public activities
        /// </summary>
        /// <returns></returns>
        public async Task<List<Activity>> GetActivities()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return await context.Activities.ToListAsync();
            }
        }

        /// <summary>
        /// Returns activities created by the authenticated user
        /// </summary>
        /// <returns></returns>
        [Route(template: "api/activities/owned")]
        public async Task<List<Activity>> GetUserActivities()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var userId = User.Identity.GetUserId();
                return await context.Activities
                    .Where(a => a.UserId == userId)
                    .ToListAsync();
            }
        }

        /// <summary>
        /// Returns activities subscribed by the authenticated user
        /// </summary>
        /// <returns></returns>
        [Route(template: "api/activities/subscribed")]
        public async Task<List<Activity>> GetSubscribedActivities()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var userId = User.Identity.GetUserId();
                return await context.UserActivity
                    .Where(a => a.UserID == userId)
                    .Select(a => a.Activity)
                    .ToListAsync();
            }
        }
    }
}
