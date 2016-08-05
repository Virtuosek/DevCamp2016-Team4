using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BeeBack.Web.Models;
using Microsoft.AspNet.Identity;

namespace BeeBack.Web.Controllers.Api
{
    public class SubscriptionController : BaseApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // PUT: api/Subscription/5
        [Route(template:"api/subscription/add/{id}")]
        [HttpPost]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> AddUserActivity(Guid id)
        {
            if (db.Activities.Any(a => a.ID == id))
            {
                var userActivity = new UserActivity()
                {
                    ActivityID = id,
                    UserID = User.Identity.GetUserId()
                };

                db.UserActivity.Add(userActivity);
                await db.SaveChangesAsync();
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Subscription/5
        [Route(template: "api/subscription/remove/{id}")]
        [HttpPost]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> RemoveUserActivity(Guid id)
        {
            var userId = User.Identity.GetUserId();

            var userActivity = db.UserActivity.FirstOrDefault(ua => ua.UserID == userId && ua.ActivityID == id);

            if (userActivity == null)
            {
                return NotFound();
            }

            db.UserActivity.Remove(userActivity);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserActivityExists(Guid id)
        {
            return db.UserActivity.Count(e => e.ID == id) > 0;
        }
    }
}