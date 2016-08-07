using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;

namespace BeeBack.Model
{
    public class User : ObservableObject
    {
        private const string _unknownUserUrl = "ms-appx:///Assets/incognitoUser.png";
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }

        private string _pictureUrl;

        public string PictureUrl
        {
            get { return string.IsNullOrEmpty(_pictureUrl) ? _unknownUserUrl : _pictureUrl; }
            set
            {
                _pictureUrl = value;
                RaisePropertyChanged(() => PictureUrl);
            }
        }

        public DateTime BirthDate { get; set; }
        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - BirthDate.Year;

                if (BirthDate > today.AddYears(-age))
                    age--;
                return age;
            }
        }
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
