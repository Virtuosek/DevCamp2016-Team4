using BeeBack.Model;
using BeeBack.Pages;
using BeeBack.Services;
using BeeBack.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BeeBack.ViewModel
{
    public class SplashScreenViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _navigationService;
        private readonly IDataService _dataService;
        private readonly IDialogService _dialogService;
        private readonly IStorageService _storageService;

        public ICommand LoadingCommand { get; set; }

        public SplashScreenViewModel(ICustomNavigationService navigationService, 
            IDataService dataService, 
            IDialogService dialogService,
            IStorageService storageService)
        {
            _navigationService = navigationService;
            _dataService = dataService;
            _dialogService = dialogService;
            _storageService = storageService;

            LoadingCommand = new RelayCommand(OnLoading);
        }

        private async void OnLoading()
        {
            try
            {
                var userInfos = await GetUserInfos();
                _dataService.Initialize(userInfos.UserName, userInfos.Password);

                var isCredentialOK = await _dataService.CheckCredentials();
                _navigationService.NavigateTo(isCredentialOK ? typeof(RootPage) : typeof(LoginPage));
            }
            catch
            {
                _navigationService.NavigateTo(typeof(LoginPage));
            }

        }

        private async Task<UserInfos> GetUserInfos()
        {
            var folder = await _storageService.GetFolder(Folder.Local);
            var fullPath = Path.Combine(folder.Path, "UserInfos");
            var serializedUserInfos = await _storageService.GetText(fullPath);
            var userInfos = JsonConvert.DeserializeObject<UserInfos>(serializedUserInfos);

            return userInfos;
        }

    }
}
