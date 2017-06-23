using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreLocation;
using xBountyHunter.iOS;

[assembly:Xamarin.Forms.Dependency(typeof(GetLocationiOs))]
namespace xBountyHunter.iOS
{
    public class GetLocationiOs : DependencyServices.IGetLocation
    {
        private CLLocationManager locMgr;
        private Dictionary<string, string> loc;
        public void activarGPS()
        {
            this.locMgr = new CLLocationManager();
            this.locMgr.PausesLocationUpdatesAutomatically = false;
            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                locMgr.RequestAlwaysAuthorization();
            }

            if (UIDevice.CurrentDevice.CheckSystemVersion(9, 0))
            {
                locMgr.AllowsBackgroundLocationUpdates = true;
            }

            if (CLLocationManager.LocationServicesEnabled)
            {
                locMgr.DesiredAccuracy = 1;
                locMgr.LocationsUpdated += (object sender, CLLocationsUpdatedEventArgs e) =>
                 {
                     loc = new Dictionary<string, string>();
                     loc.Add("Lat", e.Locations[e.Locations.Length - 1].Coordinate.Latitude.ToString());
                     loc.Add("Lon", e.Locations[e.Locations.Length - 1].Coordinate.Longitude.ToString());
                     System.Diagnostics.Debug.WriteLine("Detectando (Lat {0}, Lon {1})", loc["Lat"], loc["Lon"]);
                 };
                locMgr.StartUpdatingLocation();
            }
        }

        public void apagarGPS()
        {
            if(locMgr != null)
            {
                locMgr.StopUpdatingLocation();
            }
        }

        public Dictionary<string, string> getLocation()
        {
            return loc;
        }
    }
}