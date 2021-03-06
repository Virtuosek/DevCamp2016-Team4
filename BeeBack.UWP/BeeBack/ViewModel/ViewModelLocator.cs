﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using BeeBack.Model;
using BeeBack.Pages;
using BeeBack.Services.Interfaces;
using BeeBack.Services;

namespace BeeBack.ViewModel
{
    public class ViewModelLocator
    {
        public const string SecondPageKey = "SecondPage";
        public const string LoginPage = "LoginPage";
        public const string RootPage = "RootPage";

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<ICustomNavigationService, CustomNavigationService>();
            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<IStorageService, StorageService>();

            if (ViewModelBase.IsInDesignModeStatic)
                SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
            else
                SimpleIoc.Default.Register<IDataService, DataService>();

            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<MyActivitiesViewModel>();
            SimpleIoc.Default.Register<ActivityViewModel>();
            SimpleIoc.Default.Register<SplashScreenViewModel>();
            SimpleIoc.Default.Register<UserViewModel>();
            SimpleIoc.Default.Register<ActivityEditViewModel>();
        }

        public LoginViewModel LoginVM => ServiceLocator.Current.GetInstance<LoginViewModel>();
        public MyActivitiesViewModel MyActivitiesVM => ServiceLocator.Current.GetInstance<MyActivitiesViewModel>();
        public ActivityViewModel ActivityVM => ServiceLocator.Current.GetInstance<ActivityViewModel>();
        public SplashScreenViewModel SplashScreenVM => ServiceLocator.Current.GetInstance<SplashScreenViewModel>();
        public UserViewModel UserVM => ServiceLocator.Current.GetInstance<UserViewModel>();
        public ActivityEditViewModel ActivityEditVM => ServiceLocator.Current.GetInstance<ActivityEditViewModel>();
    }
}
