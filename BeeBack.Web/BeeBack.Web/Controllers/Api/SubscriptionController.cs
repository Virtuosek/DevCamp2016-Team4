using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BeeBack.Data.Models;
using BeeBack.Web.Models;
using Microsoft.AspNet.Identity;

namespace BeeBack.Web.Controllers.Api
{
    public class SubscriptionController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // PUT: api/Subscription/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PostUserActivity(Guid id)
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
        [ResponseType(typeof(UserActivity))]
        public async Task<IHttpActionResult> DeleteUserActivity(Guid id)
        {
            var userId = User.Identity.GetUserId();

            var userActivity = db.UserActivity.FirstOrDefault(ua => ua.UserID == userId && ua.ActivityID == id);

            if (userActivity == null)
            {
                return NotFound();
            }

            db.UserActivity.Remove(userActivity);
            await db.SaveChangesAsync();

            return Ok(userActivity);
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