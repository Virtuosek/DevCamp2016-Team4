using BeeBack.Messages;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace BeeBack.Pages
{
    public sealed partial class ActivityPage : Page
    {
        public ActivityPage()
        {
            this.InitializeComponent();

            Messenger.Default.Register<ActivityMapCoordinateMessage>(this, OnCoordinateReceived);
        }

        private void OnCoordinateReceived(ActivityMapCoordinateMessage message)
        {
            MapControl.Center = new Windows.Devices.Geolocation.Geopoint(new Windows.Devices.Geolocation.BasicGeoposition
            {
                Latitude = message.Latitude,
                Longitude = message.Longitude
            });

            MapControl.ZoomLevel = 8;
        }
    }

    //public class PointOfInterest
    //{
    //    public PointOfInterest()
    //    {
    //        this.MoreInfo = "At a glance info info about this Point of interest";
    //        this.NormalizedAnchorPoint = new Point(0.5, 1);
    //    }
    //    public string DisplayName { get; set; }
    //    public Geopoint Location { get; set; }
    //    public Uri ImageSourceUri { get; set; }
    //    public string MoreInfo { get; set; }
    //    public Point NormalizedAnchorPoint { get; set; }
    //}

    //public class PointOfInterestsManager
    //{
    //    public List<PointOfInterest> FetchPOIs(BasicGeoposition center)
    //    {
    //        List<PointOfInterest> pois = new List<PointOfInterest>();
    //        pois.Add(new PointOfInterest()
    //        {
    //            DisplayName = "Place One",
    //            ImageSourceUri = new Uri("ms-appx:///Assets/PinBee.png", UriKind.RelativeOrAbsolute),
    //            Location = new Geopoint(new BasicGeoposition()
    //            {
    //                Latitude = center.Latitude + 0.001,
    //                Longitude = center.Longitude - 0.001
    //            })
    //        });
    //        return pois;
    //    }
    //}
}
