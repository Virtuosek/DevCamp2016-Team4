using BeeBack.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
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
        public RelayCommand Selected
        {
            get
            {
                return new RelayCommand(_selected);

            }
        }
        private void _selected()
        {
            UserSelectedMessage msg = new UserSelectedMessage();
            msg.SelectedUser = this;
            Messenger.Default.Send<UserSelectedMessage>(msg);
        }

        public User()
        {
            Activities = new List<Activity>();
            OwnedActivities = new List<Activity>();
        }
    }
}
