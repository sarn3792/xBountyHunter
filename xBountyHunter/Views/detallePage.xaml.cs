using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xBountyHunter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class detallePage : ContentPage
    {
        private Models.mFugitivos fugitivo = new Models.mFugitivos();
        public detallePage(Models.mFugitivos fugitivo)
        {
            InitializeComponent();
            this.fugitivo = fugitivo;
            Title = this.fugitivo.Name;
        }
    }
}