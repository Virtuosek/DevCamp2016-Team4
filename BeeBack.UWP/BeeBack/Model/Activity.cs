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
    public class Activity : ObservableObject
    {
        private const string _emptyActivityUrl = "ms-appx:///Assets/football.png";

        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
        private string _pictureurl;
        public bool IsSubscribed { get; set; }

        public string PictureUrl
        {
            get
            {
                return string.IsNullOrEmpty(_pictureurl) ? _emptyActivityUrl : _pictureurl;
            }
            set { _pictureurl = value; }
        }


        public string UserId { get; set; }
        private User _owner;

        public User Owner
        {
            get { return _owner; }
            set
            {
                _owner = value;
                RaisePropertyChanged(() => Owner);
            }
        }

        public Guid? DriverId { get; set; }

        private User _driver;

        public User Driver
        {
            get
            {
                if (_driver == null)
                    _driver = new User();
                return _driver;
            }
            set
            {
                _driver = value;
                RaisePropertyChanged(() => Driver);
            }
        }

        public List<User> Members { get; set; }
        public RelayCommand Save
        {
            get
            {
                return new RelayCommand(_save);
            }
        }
        private void _save()
        {
            if (this.ID == null)
            {
                // Append
            }
            else
            {
                // update
            }
        }
        public RelayCommand Selected
        {
            get
            {
                return new RelayCommand(_selected);
            }
        }
        private void _selected()
        {
            ActivitySelectedMessage msg = new ActivitySelectedMessage();
            msg.SelectedActivity = this;
            Messenger.Default.Send<ActivitySelectedMessage>(msg);
        }
        public Activity()
        {
            Members = new List<User>();
            Owner = new User();
            Driver = new User();
        }

    }
}
