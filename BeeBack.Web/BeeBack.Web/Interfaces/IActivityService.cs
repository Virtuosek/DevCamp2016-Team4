using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeeBack.Web.Models;

namespace BeeBack.Web.Interfaces
{
    public interface IActivityService : IDisposable
    {
        Task<IEnumerable<Activity>> GetActivities(bool includeUserActivities = false);
        Task<List<Activity>> GetUserActivities(string userId);
        Task<List<Activity>> GetSubscribedActivities(string userId);
        Task<Activity> GetActivity(Guid id);
        Task AddActivity(Activity activity);
        Task EditActivity(Activity activity);
        Task DeleteActivity(Activity activity);
    }
}