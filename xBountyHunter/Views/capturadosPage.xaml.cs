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
    public partial class capturadosPage : ContentPage
    {
        public capturadosPage()
        {
            InitializeComponent();
            Extras.listaFugitivos listaFugitivos = new Extras.listaFugitivos();
            List<Models.mFugitivos> capturados = listaFugitivos.ocFugitivos;
            list.ItemsSource = capturados;
        }

        private void list_ItemTapped(object sender, ItemTappedEventArgs args)
        {
            Models.mFugitivos fugitivo = (Models.mFugitivos)args.Item;
            Navigation.PushAsync(new Views.detallePage(fugitivo));
        }
    }
}