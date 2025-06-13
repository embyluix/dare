using abp;
using abp1;
using System;
using Xamarin.Forms;

namespace DAREApp
{
    public partial class InicioSesionPage : ContentPage
    {
        public InicioSesionPage()
        {
            InitializeComponent();
        }
        private async void inicio(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
        private async void crear(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistroPage());
        }
        private async void omitir(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new omitr());
        }
    }
}
