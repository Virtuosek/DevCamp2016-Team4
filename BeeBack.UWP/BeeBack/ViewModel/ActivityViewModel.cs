using BeeBack.Messages;
using BeeBack.Model;
using BeeBack.Pages;
using BeeBack.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
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
        public ActivityViewModel(IDataService dataService)
        {
            _dataService = dataService;            
            Messenger.Default.Register<UserSelectedMessage>(this, _userselectedmessage);
            _activity = new Activity();
            _activity.ID = Guid.NewGuid();
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
        private IDataService _dataService;
        private async Task CheckMembers()
        {
            if (Activity.Owner.EMailAddress == null)
            {
                Activity.Owner = await _dataService.GetUser(Activity.UserId);
            }
        }
        public Activity Activity
        {
            get { return _activity; }
            set {
                _activity = value;
                DispatcherHelper.CheckBeginInvokeOnUI(async () =>
                {
                    await CheckMembers();
                });
                RaisePropertyChanged("Activity");
            }
        }

    }
}
