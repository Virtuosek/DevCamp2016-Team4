using BeeBack.Messages;
using BeeBack.Pages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeBack.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel()
        {
            DoLogin = new RelayCommand(DoLoginExecute);//, CanDoLoginExecute);

        }
        
        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; RaisePropertyChanged("Username"); }
        }
        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; RaisePropertyChanged("Password"); }
        }

        public RelayCommand DoLogin { get; set; }
        private void DoLoginExecute()
        {
            // Check login
            NavigationMessage msg = new NavigationMessage();
            msg.DestinationPageType = typeof(MyActivitiesPage);
            Messenger.Default.Send<NavigationMessage>(msg);
        }
        private bool CanDoLoginExecute()
        {
            bool EmptyUserName = string.IsNullOrEmpty(Username);
            bool EmptyPassword = string.IsNullOrEmpty(Password);
            bool rst= (!EmptyUserName && !EmptyPassword);
            return rst;            
        }
    }
}
