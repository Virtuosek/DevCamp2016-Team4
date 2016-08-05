using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeBack.Model
{
    public class User : ObservableObject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public string EMailAddress { get; set; }
        public string Password { get; set; }
        public string MobilePhone { get; set; }
        public List<Activity> Activities { get; set; }
        public List<Activity> OwnedActivities { get; set; }

        public User()
        {
            Activities = new List<Activity>();
            OwnedActivities = new List<Activity>();
        }
    }
}
