using BeeBack.Model;
using GalaSoft.MvvmLight;
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
            MyActivitiesList = new ObservableCollection<Activity>();
            CreateDummy();
        }
        private void CreateDummy()
        {
            Activity a;
            for (int i = 0; i<50; i++)
            {
                a = new Activity();
                a.Description = " ksjf mlks jflksfs kjlkds jfmlks jflkds jflkds jflkds jflksd jfl kjld mj dmlkq jmlk jflkjf dsml lkj fmlksj mlkds lksj flkds jflkjs lkfj dsjf lk";
                a.Title = "Conduire les enfants à l'école tous les mardis matin";
                MyActivitiesList.Add(a);
            }

        }
        public ObservableCollection<Activity> MyActivitiesList { get; set; }

    }
}
