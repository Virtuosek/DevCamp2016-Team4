using BeeBack.Pages;
using BeeBack.Services.Interfaces;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BeeBack.Services
{
    public class CustomNavigationService : ICustomNavigationService
    {
        private readonly NavigationService _navigationService;
        private Dictionary<Type, string> _pages;

        public CustomNavigationService()
        {
            _navigationService = new NavigationService();

            _pages = new Dictionary<Type, string>();
            RegisterKey();
        }

        public void NavigateTo(Type type)
        {
            try
            {
                var page = _pages[type];
                _navigationService.NavigateTo(page);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Page is not registered : {ex.Message}");
            }
        }

        private void RegisterKey()
        {
            _pages.Add(typeof(SecondPage), "SecondPageKey");
            _pages.Add(typeof(LoginPage), "LoginPage");
            _pages.Add(typeof(RootPage), "RootPage");

            foreach (var page in _pages)
            {
                _navigationService.Configure(page.Value, page.Key);
            }
        }

    }
}
