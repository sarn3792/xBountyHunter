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
using Xamarin.Forms;
using xBountyHunter.CustomRenders;
using xBountyHunter.Droid.CustomRenders;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;
using Android.Gms.Maps.Model;

[assembly:ExportRenderer(typeof(CustomMap), typeof(CustomMapDroid))]
namespace xBountyHunter.Droid.CustomRenders
{
    public class CustomMapDroid : MapRenderer
    {
        MapCircle circle;
        bool isDrawn;

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            try
            {
                base.OnElementChanged(e);

                if (e.OldElement != null)
                {

                }

                if (e.NewElement != null)
                {
                    var formsMap = (CustomMap)e.NewElement;
                    circle = formsMap.Circle;
                    Control.GetMapAsync(this);
                }
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                base.OnElementPropertyChanged(sender, e);

                if (e.PropertyName.Equals("VisibleRegion") && !isDrawn)
                {
                    var circleOption = new CircleOptions();
                    circleOption.InvokeCenter(new LatLng(circle.Position.Latitude, circle.Position.Longitude));
                    circleOption.InvokeRadius(circle.Radius);
                    circleOption.InvokeFillColor(0X66FF0000);
                    circleOption.InvokeStrokeColor(0X66FF0000);
                    circleOption.InvokeStrokeWidth(0);

                    NativeMap.AddCircle(circleOption);
                    isDrawn = true;
                }
            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}