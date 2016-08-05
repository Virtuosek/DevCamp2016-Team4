using BeeBack.Messages;
using BeeBack.Model;
using BeeBack.Pages;
using BeeBack.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeBack.ViewModel
{
    public class MyActivitiesViewModel : ViewModelBase
    {
        public ObservableCollection<Activity> AllActivities { get; set; }
        private readonly IDataService _dataService;

        public MyActivitiesViewModel(IDataService dataService)
        {
            _dataService = dataService;

            Messenger.Default.Register<ActivitySelectedMessage>(this, _activityselectedmessage);

            LoadDatas();
        }

        private async void LoadDatas()
        {
            AllActivities = new ObservableCollection<Activity>(await _dataService.GetAllPublicActivities());
            RaisePropertyChanged(() => AllActivities);
        }

        private void _activityselectedmessage(ActivitySelectedMessage msg)
        {
            // mettre référence à activité sélectionnée
            ServiceLocator.Current.GetInstance<ActivityViewModel>().Activity = msg.SelectedActivity;

            NavigationMessage msgnav = new NavigationMessage();
            msgnav.DestinationPageType = typeof(ActivityPage);
            Messenger.Default.Send<NavigationMessage>(msgnav);
        }

    }
}
