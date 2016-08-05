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
        public int ID { get; set; }
        public int FkUser { get; set; }
        public User Owner { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<User> Members { get; set; }
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
