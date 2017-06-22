using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using UIKit;
using System.IO;
using xBountyHunter.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(CameraiOS))]
namespace xBountyHunter.iOS
{
    public class CameraiOS : DependencyServices.ICamera
    {
        public Task<string> takePhoto()
        {
            TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();

            Camera.TakePicture(UIApplication.SharedApplication.KeyWindow.RootViewController,
                (imagePickerResult) =>
                {
                    if(imagePickerResult == null)
                    {
                        tcs.TrySetResult(null);
                        return;
                    }

                    var photo = imagePickerResult.ValueForKey(new NSString("UIImagePickerControllerOriginalImage")) as UIImage;

                    var documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    string jpgFilename = Path.Combine(documentsDirectory, String.Format("fugitivo_{0}.jpg", Guid.NewGuid()));

                    NSData imgData = photo.AsJPEG();
                    NSError err = null;

                    if(imgData.Save(jpgFilename, false, out err))
                    {
                        string result = "";
                        result = jpgFilename;
                        tcs.TrySetResult(result);
                    }
                    else
                    {
                        tcs.TrySetException(new Exception(err.LocalizedDescription));
                    }
                });

            return tcs.Task;
        }

        public static class Camera
        {
            static UIImagePickerController picker;
            static Action<NSDictionary> _callback;

            static void Init()
            {
                if (picker != null)
                    return;

                picker = new UIImagePickerController();
                picker.Delegate = new CameraDelegate();
            }

            class CameraDelegate : UIImagePickerControllerDelegate
            {
                public override void FinishedPickingMedia(UIImagePickerController picker, NSDictionary info)
                {
                    var cb = _callback;
                    _callback = null;

                    picker.DismissViewController(true, (Action)null);
                    cb(info);
                }

                public override void Canceled(UIImagePickerController picker)
                {
                    var cb = _callback;
                    _callback = null;

                    picker.DismissViewController(true, (Action)null);
                    cb(null);
                }
            }

            public static void TakePicture(UIViewController parent, Action <NSDictionary> callback)
            {
                Init();
                picker.SourceType = UIImagePickerControllerSourceType.Camera;
                _callback = callback;
                parent.PresentViewController((UIViewController)picker, true, (Action)null);
            }
        }
    }
}