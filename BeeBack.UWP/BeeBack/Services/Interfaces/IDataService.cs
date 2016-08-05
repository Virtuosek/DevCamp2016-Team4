using BeeBack.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeeBack.Services.Interfaces
{
    public interface IDataService
    {
        void Initialize(string username, string password);
        Task<DataItem> GetData();
        Task<bool> CheckCredentials();
        Task<List<Activity>> GetUserActivities();
        Task<List<Activity>> GetSubscribedActivities();
        Task<List<Activity>> GetAllPublicActivities();
    }
}