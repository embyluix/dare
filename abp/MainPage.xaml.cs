using System;
using abp;
using Xamarin.Forms;

namespace abp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnPerfilTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new configuracion());
        }
        private async void OnNotificacionesTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NotificacionesPage());
        }
        private async void OnBusquedaTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new buscador());
        }

        private async void OntrofeosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LogrosPage());
        }

        private async void OnHistorialTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistorialBancarioPage());
        }

        private async void OnEventoTapped(object sender, EventArgs e)
        {
            await DisplayAlert("Evento", "Has tocado el evento.", "OK");
        }
        private async void OnImageTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new buscador());
        }
        private async void OnAgregareventoPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgregarEventoPage());
        }

        private async void OnTuEventoPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MostrarEventosPage());
        }
    }
}
