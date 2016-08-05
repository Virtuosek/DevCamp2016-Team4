using BeeBack.Messages;
using BeeBack.Model;
using BeeBack.Pages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeBack.ViewModel
{
    public class ActivityViewModel : ViewModelBase
    {
        public ActivityViewModel()
        {
            Messenger.Default.Register<UserSelectedMessage>(this, _userselectedmessage);
            _activity = new Activity();
            _activity.ID = 5;
            _activity.FkUser = 1;
            _activity.Description = "description flkjds mlf jdsqmlkdslkfj smlk jflks jflkdsjf  fds jflksj flk jsflkds jlkf jsmlf jmls jfmlsq jfmlkds jflkds jflkds jfmlkds jfmlkds jf lkdsjfmlqs";
            _activity.Title = "Titre de l'activité";
            User u;
            for (int j = 0; j < 10; j++)
            {
                u = new User();
                u.EMailAddress = "tot@totofds.be";
                u.Name = $"{j}Smith";
                u.FirstName = "John";
                u.MobilePhone = "+32475123456";
                if (j == 0)
                {
                    _activity.Owner = u;
                }
                _activity.Members.Add(u);
            }
        }
        private void _userselectedmessage(UserSelectedMessage msg)
        {
            NavigationMessage msgnav = new NavigationMessage();
            ServiceLocator.Current.GetInstance<UserViewModel>().User = msg.SelectedUser;
            msgnav.DestinationPageType = typeof(UserPage);
            Messenger.Default.Send<NavigationMessage>(msgnav);
        }
        private Activity _activity;

        public Activity Activity
        {
            get { return _activity; }
            set { _activity = value; RaisePropertyChanged("Activity"); }
        }

    }
}
