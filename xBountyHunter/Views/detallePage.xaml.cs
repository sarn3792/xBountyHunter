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
        private Extras.databaseManager db = new Extras.databaseManager();
        public detallePage(Models.mFugitivos fugitivo)
        {
            InitializeComponent();
            this.fugitivo = fugitivo;
            Title = this.fugitivo.Name;
            img.Source = ImageSource.FromFile(fugitivo.Foto);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            int result = db.deleteItem(fugitivo.ID);
            if(result == 1)
            {
                await DisplayAlert("Eliminado", "El fugitivo " + fugitivo.Name + " ha sido eliminado", "Aceptar");
            }
            else
            {
                await DisplayAlert("Error", "Error al borrar al fugitivo", "Aceptar");
            }

            db.closeConnection();
            MessagingCenter.Send<Page>(this, "Update");
            await Navigation.PopAsync();
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new mapPage(this.fugitivo));
        }
    }
}