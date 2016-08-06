using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;

namespace BeeBack.Model
{
    public class User : ObservableObject
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string PictureUrl { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }

        public string FullName { get { return $"{Firstname} {Lastname}"; } }
        public List<Activity> Activities { get; set; }
        public List<Activity> OwnedActivities { get; set; }

        public User()
        {
            Activities = new List<Activity>();
            OwnedActivities = new List<Activity>();
        }
    }
}
