using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace xBountyHunter.Views
{
    public class capturarPage : ContentPage
    {
        private Models.mFugitivos Fugitivo = new Models.mFugitivos();
        private Label fugitivoSuelto;
        private Button bcapturar;
        private Button beliminar;
        private StackLayout verticalStackLayout;
        public capturarPage(Models.mFugitivos fugitivo)
        {
            Fugitivo.Name = fugitivo.Name;
            Fugitivo.ID = fugitivo.ID;

            fugitivoSuelto = new Label
            {
                Text = "El fugitivo sigue suelto...",
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Center
            };

            bcapturar = new Button
            {
                Text = "Capturar",
                WidthRequest = 200,
                BorderColor = Color.Black,
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center
            };

            beliminar = new Button
            {
                Text = "Eliminar",
                WidthRequest = 200,
                BorderColor = Color.Black,
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center
            };

            verticalStackLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            Title = this.Fugitivo.Name;
            verticalStackLayout.Children.Add(fugitivoSuelto);
            verticalStackLayout.Children.Add(bcapturar);
            verticalStackLayout.Children.Add(beliminar);

            Content = verticalStackLayout;
        }
    }
}