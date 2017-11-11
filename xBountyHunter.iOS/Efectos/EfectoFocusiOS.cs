using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using xBountyHunter.iOS.Efectos;
using Xamarin.Forms.Platform.iOS;
using System.ComponentModel;

[assembly: ResolutionGroupName("xBountyHunter")]
[assembly: ExportEffect(typeof(EfectoFocusiOS), "FocusEffect")]
namespace xBountyHunter.iOS.Efectos
{
    public class EfectoFocusiOS : PlatformEffect
    {
        UIColor backgroundColor;
        protected override void OnAttached()
        {
            try
            {
                Control.BackgroundColor = backgroundColor = UIColor.Orange;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override void OnDetached()
        {
            
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
            try
            {
                if (args.PropertyName == "IsFocused")
                {
                    if (Control.BackgroundColor == backgroundColor)
                    {
                        Control.BackgroundColor = UIColor.LightGray;
                    }
                    else
                    {
                        Control.BackgroundColor = backgroundColor;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}