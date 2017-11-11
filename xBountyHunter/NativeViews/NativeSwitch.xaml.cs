using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xBountyHunter.NativeViews
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NativeSwitch : ContentPage
    {
        public NativeSwitch()
        {
            InitializeComponent();
            BindingContext = new NativeSwitchViewModel();
        }
    }
}