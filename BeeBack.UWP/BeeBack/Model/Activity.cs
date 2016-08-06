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
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public string UserId { get; set; }
        private User _owner;

        public User Owner
        {
            get { return _owner; }
            set { _owner = value;
                RaisePropertyChanged("Owner"); }
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
            if (this.ID==null )
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
        }

    }
}
