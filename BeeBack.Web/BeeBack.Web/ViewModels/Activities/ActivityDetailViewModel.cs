using System.Globalization;
using BeeBack.Web.Models;

namespace BeeBack.Web.ViewModels.Activities
{
    public class ActivityDetailViewModel : ActivityViewModel
    {
        public string ActivityLatitude { get; set; }
        public string ActivityLongitude { get; set; }
        
        public void Fill(Activity activity)
        {
            ActivityLatitude = activity.Location.Latitude.ToString("F", CultureInfo.InvariantCulture);
            ActivityLongitude = activity.Location.Longitude.ToString("F", CultureInfo.InvariantCulture);
        }
    }
}