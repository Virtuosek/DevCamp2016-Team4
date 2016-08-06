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
        public Guid ID { get; set; }
        //{"Claims":[],"Logins":[],"Roles":[],
        //"UserActivities":null,
        //"Activities":null,
        //,"PasswordHash":"AHeOYy6dkT2fFgJ+8gQ6D3i/HcAqYZgXT56cC6NI87LBLMeYeQ1k0GYiQSJBtSJfeQ==","SecurityStamp":"b2a71f39-4b01-4f7c-873d-91f36e20cc29",
        //"TwoFactorEnabled":false,"LockoutEndDateUtc":null,"LockoutEnabled":true,"AccessFailedCount":0,
        public string UserName { get; set; }
        public string Lastname { get; set; }
        public string Name { get { return Lastname; } }
        public string Firstname { get; set; }
        public string FirstName { get { return Firstname; } }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string EMailAddress
        {
            get { return Email; }
        }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
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
