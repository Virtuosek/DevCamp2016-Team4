using BeeBack.Model;
using BeeBack.Services;
using BeeBack.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
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
        private readonly IStorageService _storageService;

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

        public LoginViewModel(ICustomNavigationService navigationService,
            IDataService dataService,
            IDialogService dialogService,
            IStorageService storageService)
        {
            _navigationService = navigationService;
            _dataService = dataService;
            _dialogService = dialogService;
            _storageService = storageService;

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
                {
                    await SaveUserInfos();
                    _navigationService.NavigateTo(typeof(RootPage));
                }
                else
                    await _dialogService.ShowMessage("Votre mot de passe ou votre nom d'utilisateur est incorrect", "Erreur de connexion");

            }
            catch (UnauthorizedAccessException ex)
            {
                await _dialogService.ShowMessage("Votre mot de passe ou votre nom d'utilisateur est incorrect", "Erreur de connexion");
                Debug.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                await _dialogService.ShowMessage("Une erreur est survenue lors de la connexion aux serveurs", "Erreur de connexion");
                Debug.WriteLine(ex.Message);
            }
        }

        private async Task SaveUserInfos()
        {
            var userInfos = new UserInfos
            {
                Password = Password,
                UserName = Username,
            };

            var localFolder = await _storageService.GetFolder(Folder.Local);
            await _storageService.SaveText(localFolder, "UserInfos", JsonConvert.SerializeObject(userInfos));
        }
    }
}
