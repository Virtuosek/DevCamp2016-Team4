using System.Collections.Generic;
using BeeBack.Web.ViewModels.Activities;

namespace BeeBack.Web.Interfaces
{
    public interface IActivityService
    {
        List<ActivityListItemViewModel> GetActivityListItemViewModels();
    }
}