using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using xBountyHunter.CustomRenders;
using xBountyHunter.iOS.CustomRenders;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(EntryCustomRender), typeof(EntryCustomRenderiOS))]
namespace xBountyHunter.iOS.CustomRenders
{
    public class EntryCustomRenderiOS : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if(Control != null)
            {
                Control.BackgroundColor = UIColor.FromRGB(204,153,255);
                Control.BorderStyle = UITextBorderStyle.Line;
            }
        }
    }
}