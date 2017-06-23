using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using xBountyHunter.Droid;
using Android.Locations;

[assembly:Xamarin.Forms.Dependency(typeof(GetLocationAndroid))]
namespace xBountyHunter.Droid
{
    public class GetLocationAndroid : Java.Lang.Object, DependencyServices.IGetLocation, ILocationListener
    {
        private LocationManager locationManager;
        private Dictionary<string, string> loc;
        public void activarGPS()
        {
            try
            {
                Context cnt = Android.App.Application.Context;
                this.locationManager = cnt.GetSystemService(Context.LocationService) as LocationManager;
                this.locationManager.RequestLocationUpdates(LocationManager.GpsProvider, 0, 0, this);
                System.Diagnostics.Debug.WriteLine("Activando GPS");

                Criteria criteria = new Criteria();
                criteria.Accuracy = Accuracy.Fine;
                string provider = locationManager.GetBestProvider(criteria, true);

                Location location = locationManager.GetLastKnownLocation(provider);
                if(location != null)
                {
                    newLocation(location);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public void apagarGPS()
        {
            if(this.locationManager != null)
            {
                try
                {
                    locationManager.RemoveUpdates(this);
                    System.Diagnostics.Debug.WriteLine("Apagando GPS...");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
        }

        public Dictionary<string, string> getLocation()
        {
            return loc;
        }

        public void OnLocationChanged(Location location)
        {
            newLocation(location);
        }

        public void OnProviderDisabled(string provider) //if gps is not enabled
        {
            
        }

        public void OnProviderEnabled(string provider)
        {
            
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            
        }

        private void newLocation(Location location)
        {
            this.loc = new Dictionary<string, string>();
            loc.Add("Lat", location.Latitude.ToString());
            loc.Add("Lon", location.Longitude.ToString());
            System.Diagnostics.Debug.WriteLine(String.Format("Detectando (Lat {0},Lon {1} )", loc["Lat"], loc["Lon"]));
        }
    }
}