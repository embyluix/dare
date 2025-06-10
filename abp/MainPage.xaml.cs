using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private async void trofeos(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LogrosPage());
        }
        private async void OnImageTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new prueba());
        }

        private async void perfil(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PerfilPage());
        }
        private async void historial(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistorialBancarioPage());
        }


    }

}
