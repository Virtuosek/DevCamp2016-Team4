using System;
using BeeBack.Web.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using BeeBack.Web.Interfaces;
using Microsoft.AspNet.Identity;
using BeeBack.Web.Services;

namespace BeeBack.Web.Controllers.Api
{
    public class ActivitiesController : BaseApiController
    {
        private readonly IActivityService _activityService;

        public ActivitiesController()
        {
            _activityService = new ActivityService();
        }

        public ActivitiesController(IActivityService activityService)
        {
            //remove this contructor, added so I can wwork on mobile part
            _activityService = activityService;
        }

        /// <summary>
        /// Return all public activities
        /// </summary>
        /// <returns></returns>
        public async Task<List<Activity>> GetActivities()
        {
            var activities = (await _activityService.GetActivities()).ToList();

            return activities;
        }

        [Route(template: "api/activities/getactivity")]
        public async Task<Activity> GetActivity(Guid id)
        {
            var activity = await _activityService
                .GetActivity(id);

            return activity;
        }


        /// <summary>
        /// Returns activities created by the authenticated user
        /// </summary>
        /// <returns></returns>
        [Route(template: "api/activities/owned")]
        public async Task<List<Activity>> GetUserActivities()
        {
            var activities = await _activityService.GetUserActivities(User.Identity.GetUserId());

            return activities;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(template: "api/activities/trigger/{id}")]
        public bool Trigger(Guid id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var activity = context.Activities.Find(id);
                var smsService = new SmsActivityNotificationService();
                smsService.NotifySubscribedUsers(activity);
                return true;
            }
        }
    }
}
