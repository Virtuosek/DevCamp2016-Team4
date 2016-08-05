using System.Collections.Generic;

namespace BeeBack.Web.ViewModels.Activities
{
    public class ActivitiesIndexViewModel
    {
        public IEnumerable<ActivityListItemViewModel> Activities { get; set; }
    }
}