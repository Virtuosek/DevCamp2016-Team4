using BeeBack.Messages;
using BeeBack.Model;
using BeeBack.Pages;
using BeeBack.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace BeeBack.ViewModel
{
    public class MyActivitiesViewModel : ViewModelBase
    {
        public ICommand SelectActivityCommand { get; set; }
        public Visibility AllActivitiesVisibility => AllActivities?.Count > 0 ? Visibility.Visible : Visibility.Collapsed;
        public Visibility MyActivitiesVisibility => MyActivities?.Count > 0 ? Visibility.Visible : Visibility.Collapsed;
        public Visibility MySubscriptionsVisibility => MySubscriptions?.Count > 0 ? Visibility.Visible : Visibility.Collapsed;

        public ObservableCollection<Activity> AllActivities { get; set; }
        public ObservableCollection<Activity> MyActivities { get; set; }
        public ObservableCollection<Activity> MySubscriptions { get; set; }

        private readonly IDataService _dataService;
        private readonly ICustomNavigationService _customNavigationService;

        public RelayCommand AddActivity
        {
            get
            {
                return new RelayCommand(_addactivity);
            }
        }

        private void _addactivity()
        {
            NavigationMessage msg = new NavigationMessage();
            msg.DestinationPageType = typeof(ActivityEditPage);
            Messenger.Default.Send<NavigationMessage>(msg);
        }


        public MyActivitiesViewModel(IDataService dataService, ICustomNavigationService customNavigationService)
        {
            _dataService = dataService;
            _customNavigationService = customNavigationService;

            SelectActivityCommand = new RelayCommand<SelectionChangedEventArgs>(OnSelectActivity);

            LoadDatas();
        }

        private void OnSelectActivity(SelectionChangedEventArgs obj)
        {
            if (obj.AddedItems.Count > 0)
            {
                ServiceLocator.Current.GetInstance<ActivityViewModel>().Activity = obj.AddedItems[0] as Activity;
                _customNavigationService.Navigate(typeof(ActivityPage));
            }
        }

        private async void LoadDatas()
        {
            AllActivities = new ObservableCollection<Activity>(await _dataService.GetAllPublicActivities());
            MySubscriptions = new ObservableCollection<Activity>(await _dataService.GetSubscribedActivities());
            MyActivities = new ObservableCollection<Activity>(await _dataService.GetUserActivities());

            RaisePropertyChanged(() => AllActivities);
            RaisePropertyChanged(() => AllActivitiesVisibility);
            RaisePropertyChanged(() => MySubscriptions);
            RaisePropertyChanged(() => MyActivities);
        }
    }
}
