using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeeBack.Data.Models;
using BeeBack.Web.ViewModels.Activities;

namespace BeeBack.Web.Interfaces
{
    public interface IActivityService
    {
        Task<IEnumerable<Activity>> GetActivities();

        Task<Activity> GetActivity(Guid id);
    }
}