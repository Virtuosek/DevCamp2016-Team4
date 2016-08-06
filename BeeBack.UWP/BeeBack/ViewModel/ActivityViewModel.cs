using BeeBack.Messages;
using BeeBack.Model;
using BeeBack.Pages;
using BeeBack.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BeeBack.ViewModel
{
    public class ActivityViewModel : ViewModelBase
    {
        private IDataService _dataService;
        private Activity _activity;
        public ActivityViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _activity = new Activity();
            if (IsInDesignModeStatic)
            {
                CreateDummyActivity();
            }
            else
            {
                Messenger.Default.Register<UserSelectedMessage>(this, _userselectedmessage);
            }
        }

        private void CreateDummyActivity()
        {
            _activity.ID = Guid.NewGuid();
            _activity.Description = "description flkjds mlf jdsqmlkdslkfj smlk jflks jflkdsjf  fds jflksj flk jsflkds jlkf jsmlf jmls jfmlsq jfmlkds jflkds jflkds jfmlkds jfmlkds jf lkdsjfmlqs";
            _activity.Title = "Titre de l'activité";
            User u;
            for (int j = 0; j < 10; j++)
            {
                u = new User();
                u.Lastname = $"{j}Smith";
                u.Firstname = "John";
                u.PictureUrl = "John";
                if (j == 0)
                {
                    _activity.Owner = u;
                }
                _activity.Members.Add(u);
            }
        }

        private async void _loaded()
        {
            await CheckMembers();
        }
        public RelayCommand Loaded
        {
            get
            {
                return new RelayCommand(_loaded);
            }
        }
        private void _userselectedmessage(UserSelectedMessage msg)
        {
            NavigationMessage msgnav = new NavigationMessage();
            ServiceLocator.Current.GetInstance<UserViewModel>().User = msg.SelectedUser;
            msgnav.DestinationPageType = typeof(UserPage);
            Messenger.Default.Send<NavigationMessage>(msgnav);
        }
      
        private async Task CheckMembers()
        {
            if (string.IsNullOrEmpty(Activity.Owner.Email))
            {
                Activity.Owner = await _dataService.GetUser(Guid.Parse(Activity.UserId));
                for (int i = 0; i < Activity.Members.Count; i++)
                {
                    try
                    {
                        Activity.Members[i] = await _dataService.GetUser(Activity.Members[i].ID);
                    }
                    catch
                    { }
                }
            }
        }
        public Activity Activity
        {
            get { return _activity; }
            set
            {
                _activity = value;
                RaisePropertyChanged(() => Activity);
            }
        }

    }
}
