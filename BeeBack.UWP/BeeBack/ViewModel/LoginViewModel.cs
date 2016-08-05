using BeeBack.Messages;
using BeeBack.Pages;
using BeeBack.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BeeBack.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string _password;
        private string _username;
        private readonly ICustomNavigationService _navigationService;

        public ICommand DoLogin { get; set; }

        public string Username
        {
            get { return _username; }
            set { _username = value; RaisePropertyChanged("Username"); }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; RaisePropertyChanged("Password"); }
        }

        public LoginViewModel(ICustomNavigationService navigationService)
        {
            _navigationService = navigationService;

            DoLogin = new RelayCommand(DoLoginExecute);
        }

        private void DoLoginExecute()
        {
            _navigationService.NavigateTo(typeof(RootPage));

        }
    }
}
