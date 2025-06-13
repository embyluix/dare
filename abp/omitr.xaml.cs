using System;
using abp;
using DAREApp;
using Xamarin.Forms;

namespace abp
{
    public partial class omitr : ContentPage
    {
        public omitr()
        {
            InitializeComponent();
        }

        private async void OnPerfilTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InicioSesionPage());
        }
        private async void OnNotificacionesTapped(object sender, EventArgs e)
        {
            DisplayAlert("no tienes una sesion activa", "porfavor iniciar sesion para acceder a esta funcion", "OK");
        }
        private async void OnBusquedaTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new buscador());
        }

        private async void OntrofeosClicked(object sender, EventArgs e)
        {
            DisplayAlert("no tienes una sesion activa", "porfavor iniciar sesion para acceder a esta funcion", "OK");
        }

        private async void OnHistorialTapped(object sender, EventArgs e)
        {
            DisplayAlert("no tienes una sesion activa", "porfavor iniciar sesion para acceder a esta funcion", "OK");
        }

        private async void OnEventoTapped(object sender, EventArgs e)
        {
           DisplayAlert("no tienes una sesion activa", "porfavor iniciar sesion para acceder a esta funcion", "OK");
        }
        private async void OnImageTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new buscador());
        }
        private async void OnAgregareventoPage(object sender, EventArgs e)
        {
            DisplayAlert("no tienes una sesion activa", "porfavor iniciar sesion para acceder a esta funcion", "OK");
        }

        private async void OnTuEventoPage(object sender, EventArgs e)
        {
            DisplayAlert("no tienes una sesion activa", "porfavor iniciar sesion para acceder a esta funcion", "OK");
        }
    }
}
