using BeeBack.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeBack.ViewModel
{
    public class ActivityEditViewModel : ViewModelBase
    {
        public ActivityEditViewModel()
        {
            _activity = new Activity();
        }
        public RelayCommand New
        {
            get
            {
                return new RelayCommand(_new);
            }
        }
        private void _new()
        {
            Activity = new Activity();
        }
        private Activity _activity;

        public Activity Activity
        {
            get { return _activity; }
            set { _activity = value; RaisePropertyChanged("Activity"); }
        }

    }
}
