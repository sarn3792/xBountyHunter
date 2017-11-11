using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;
using Xamarin.Forms;
using xBountyHunter.CustomRenders;

namespace xBountyHunter.Views
{
    public class mapPage : ContentPage
    {
        public mapPage(Models.mFugitivos fugitivo)
        {
            try
            {
                double lat = Convert.ToDouble(fugitivo.Lat);
                double lon = Convert.ToDouble(fugitivo.Lon);
                Position pos = new Position(lat, lon);
                MapSpan span = MapSpan.FromCenterAndRadius(pos, Distance.FromKilometers(3));
                CustomMap capturadosMap = new CustomMap(span);
                capturadosMap.MapType = MapType.Street;
                capturadosMap.IsShowingUser = false;
                Pin pin = new Pin();
                pin.Type = PinType.Place;
                pin.Position = pos;
                pin.Label = fugitivo.Name;
                capturadosMap.Circle = new MapCircle { Position = pos, Radius = 100 };
                capturadosMap.Pins.Add(pin);

                StackLayout verticalStackLayout = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };

                verticalStackLayout.Children.Add(capturadosMap);
                Content = verticalStackLayout;
            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
