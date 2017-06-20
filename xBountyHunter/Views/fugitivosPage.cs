using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace xBountyHunter.Views
{
    public class fugitivosPage : ContentPage
    {
        private ListView list = new ListView();
        public fugitivosPage()
        {
            Title = "Fugitivos";
            Extras.listaFugitivos listaFugitivos = new Extras.listaFugitivos();
            list.ItemsSource = listaFugitivos.ocFugitivos;
            list.ItemTemplate = new DataTemplate(typeof(ListViewCell));
            list.ItemTapped += listItemTapped_Tapped;
            Content = list;
        }

        public void listItemTapped_Tapped(Object sender, ItemTappedEventArgs args)
        {
            Models.mFugitivos fugitivo = (Models.mFugitivos)args.Item;
            Navigation.PushAsync(new Views.capturarPage(fugitivo));
        }
    }
}