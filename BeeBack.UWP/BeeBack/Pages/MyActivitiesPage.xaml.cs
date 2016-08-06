using System;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace BeeBack.Pages
{
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
