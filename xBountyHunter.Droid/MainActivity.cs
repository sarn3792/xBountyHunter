using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace xBountyHunter.Droid
{
    [Activity(Label = "xBountyHunter.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            Xamarin.FormsMaps.Init(this, bundle);
            LoadApplication(new xBountyApp());
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            CameraAndroid.OnResult(resultCode);
        }
    }
}

