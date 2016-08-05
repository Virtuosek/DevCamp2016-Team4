using BeeBack.Messages;
using BeeBack.Pages;
using BeeBack.Services;
using BeeBack.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private readonly IDataService _dataService;
        private readonly IDialogService _dialogService;

        public ICommand DoLogin { get; set; }

        public string Username
        {
            get { return _username; }
            set { _username = value; RaisePropertyChanged(() => Username); }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; RaisePropertyChanged(() => Password); }
        }

        public LoginViewModel(ICustomNavigationService navigationService, IDataService dataService, IDialogService dialogService)
        {
            _navigationService = navigationService;
            _dataService = dataService;
            _dialogService = dialogService;

            DoLogin = new RelayCommand(OnLoginExecute);
        }

        private async void OnLoginExecute()
        {
            try
            {
                //Todo store login info in storage
                _dataService.Initialize(Username, Password);
                var isLogged = await _dataService.CheckCredentials();

                if (isLogged)
                    _navigationService.NavigateTo(typeof(RootPage));
                else
                    await _dialogService.ShowMessage("wrong username or password", "error");

            }
            catch (UnauthorizedAccessException ex)
            {
                await _dialogService.ShowMessage("wrong username or password", "error");
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
