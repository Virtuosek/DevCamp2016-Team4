using System.Collections.Generic;
using System.Threading.Tasks;
using BeeBack.Web.ViewModels.Activities;

namespace BeeBack.Web.Interfaces
{
    public interface IActivityService
    {
        Task<List<ActivityListItemViewModel>> GetActivityListItemViewModels();
    }
}