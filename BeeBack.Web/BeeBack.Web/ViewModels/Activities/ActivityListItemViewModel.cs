namespace BeeBack.Web.ViewModels.Activities
{
    public class ActivityListItemViewModel : ActivityViewModel
    {
        public string Icon { get; set; }

        public string DescriptionExtract
        {
            get
            {
                if (Description.Length > 250) return Description.Substring(0, 250) + "...";
                return Description;
            }
        }
        
        public ActivityListItemViewModel()
        {
            Icon = "football";
        }
    }
}