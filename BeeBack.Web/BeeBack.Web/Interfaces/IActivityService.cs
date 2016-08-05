using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeeBack.Data.Models;

namespace BeeBack.Web.Interfaces
{
    public interface IActivityService : IDisposable
    {
        Task<IEnumerable<Activity>> GetActivities();
        Task<List<Activity>> GetUserActivities(string userId);
        Task<List<Activity>> GetSubscribedActivities(string userId);
        Task<Activity> GetActivity(Guid id);
        Task AddActivity(Activity activity);
        Task EditActivity(Activity activity);
        Task DeleteActivity(Activity activity);
    }
}