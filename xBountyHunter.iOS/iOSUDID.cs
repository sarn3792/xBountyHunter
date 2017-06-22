using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using xBountyHunter.iOS;

[assembly:Xamarin.Forms.Dependency(typeof(iOSUDID))]
namespace xBountyHunter.iOS
{
    public class iOSUDID : DependencyServices.IUDID
    {
        public string getUDID()
        {
            return UIDevice.CurrentDevice.IdentifierForVendor.AsString();
        }
    }
}