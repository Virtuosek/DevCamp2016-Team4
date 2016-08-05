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
    public class SplashScreenViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _navigationService;
        public ICommand LoadingCommand { get; set; }

        public SplashScreenViewModel(ICustomNavigationService navigationService)
        {
            _navigationService = navigationService;
            LoadingCommand = new RelayCommand(OnLoading);
        }

        private void OnLoading()
        {
            _navigationService.NavigateTo(false ? typeof(RootPage) : typeof(LoginPage));
        }
    }
}
