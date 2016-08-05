using BeeBack.Messages;
using BeeBack.Pages;
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
    public class SplashScreenViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _navigationService;
        private readonly IDataService _dataService;
        private readonly IDialogService _dialogService;

        public ICommand LoadingCommand { get; set; }

        public SplashScreenViewModel(ICustomNavigationService navigationService, IDataService dataService, IDialogService dialogService)
        {
            _navigationService = navigationService;
            _dataService = dataService;
            _dialogService = dialogService;

            LoadingCommand = new RelayCommand(OnLoading);
        }

        private async void OnLoading()
        {
            try
            {
                //Todo load login & password from storage
                var isCredentialOK = await _dataService.CheckCredentials();
                _navigationService.NavigateTo(isCredentialOK ? typeof(RootPage) : typeof(LoginPage));
            }
            catch
            {
                _navigationService.NavigateTo(typeof(LoginPage));
            }

        }
    }
}
