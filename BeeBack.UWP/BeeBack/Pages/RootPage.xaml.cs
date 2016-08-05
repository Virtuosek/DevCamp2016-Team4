using BeeBack.Messages;
using BeeBack.Pages;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BeeBack
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RootPage : Page
    {
        public RootPage()
        {
            this.InitializeComponent();
            //Messenger.Default.Register<NavigationMessage>(this, _navigationmessage);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //MainFrame.Navigate(typeof(LoginPage));
        }
        private void _navigationmessage(NavigationMessage msg)
        {
            MainFrame.Navigate(msg.DestinationPageType);
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(MyActivitiesPage));
        }
    }
}
