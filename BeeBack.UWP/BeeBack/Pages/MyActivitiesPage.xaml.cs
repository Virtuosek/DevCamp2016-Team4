using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace BeeBack.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MyActivitiesPage : Page
    {
        public MyActivitiesPage()
        {
            this.InitializeComponent();
        }
        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            SectionWidth = Window.Current.Bounds.Width;
        }

        public double SectionWidth
        {
            get { return (double)GetValue(SectionWidthProperty); }
            set
            {
                SetValue(SectionWidthProperty, value);
                RaisePropertyChanged("SectionWidth");
            }
        }

        public static readonly DependencyProperty SectionWidthProperty = DependencyProperty.Register("SectionWidth", typeof(double), typeof(MyActivitiesPage), new PropertyMetadata(0));

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
