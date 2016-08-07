using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BeeBack.Web.Interfaces;
using BeeBack.Web.Models;

namespace BeeBack.Web.Services
{
    public class ActivityService : IActivityService
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        public async Task<IEnumerable<Activity>> GetActivities(bool includeUserActivities = false)
        {
            IQueryable<Activity> activities = _db.Activities;
            if (includeUserActivities)
            {
                activities = activities.Include(a => a.UserActivities);
            }
            return await activities.ToListAsync();
        }

        public async Task<List<Activity>> GetUserActivities(string userId)
        {
            return await _db.Activities
                            .Where(a => a.UserId == userId)
                            .ToListAsync();
        }

        public async Task<List<Activity>> GetSubscribedActivities(string userId)
        {
            return await _db.UserActivity
                            .Where(a => a.UserID == userId)
                            .Select(a => a.Activity)
                            .ToListAsync();
        }

        public async Task<Activity> GetActivity(Guid id)
        {
            return await _db.Activities
                .FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task AddActivity(Activity activity)
        {
            _db.Activities.Add(activity);
            await _db.SaveChangesAsync();
        }

        public async Task EditActivity(Activity activity)
        {
            _db.Entry(activity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteActivity(Activity activity)
        {
            _db.Activities.Remove(activity);
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}