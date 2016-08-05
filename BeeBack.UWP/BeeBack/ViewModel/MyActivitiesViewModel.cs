using BeeBack.Messages;
using BeeBack.Model;
using BeeBack.Pages;
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
        public MyActivitiesViewModel()
        {
            Messenger.Default.Register<ActivitySelectedMessage>(this, _activityselectedmessage);
            MyActivitiesList = new ObservableCollection<Activity>();
            CreateDummy();
        }
        private void _activityselectedmessage(ActivitySelectedMessage msg)
        {
            // mettre référence à activité sélectionnée
            ServiceLocator.Current.GetInstance<ActivityViewModel>().Activity = msg.SelectedActivity;

            NavigationMessage msgnav = new NavigationMessage();
            msgnav.DestinationPageType = typeof(ActivityPage);
            Messenger.Default.Send<NavigationMessage>(msgnav);
        }
        private void CreateDummy()
        {
            Activity a;
            User u;
            for (int i = 0; i<50; i++)
            {
                a = new Activity();
                a.Description = " ksjf mlks jflksfs kjlkds jfmlks jflkds jflkds jflkds jflksd jfl kjld mj dmlkq jmlk jflkjf dsml lkj fmlksj mlkds lksj flkds jflkjs lkfj dsjf lk";
                a.Title = $"{i} Conduire les enfants à l'école tous les mardis matin";
                for (int j = 0; j<10; j++)
                {
                    u = new User();
                    u.EMailAddress = "tot@totofds.be";
                    u.Name = $"{j}Smith";
                    u.FirstName = "John";
                    u.MobilePhone = "+32475123456";
                    if (j==0)
                    {
                        a.Owner = u;
                    }
                    u.Activities.Add(a);
                    a.Members.Add(u);
                }
                MyActivitiesList.Add(a);
            }

        }
        public ObservableCollection<Activity> MyActivitiesList { get; set; }

    }
}
