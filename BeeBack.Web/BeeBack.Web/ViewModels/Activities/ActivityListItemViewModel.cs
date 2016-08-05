namespace BeeBack.Web.ViewModels.Activities
{
    public class ActivityListItemViewModel : ActivityViewModel
    {
        public string Icon { get; set; }
        
        public ActivityListItemViewModel()
        {
            Icon = "football";
        }
    }
}