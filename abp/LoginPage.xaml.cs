using System;
using abp;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace abp1
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            // Obtener los datos almacenados
            string correoGuardado = Preferences.Get("Correo", string.Empty);
            string contrasenaGuardada = Preferences.Get("Contrasena", string.Empty);

            // Obtener los datos ingresados por el usuario
            string correoIngresado = EntryCorreo.Text;
            string contrasenaIngresada = EntryContrasena.Text;

            // Validar
            if (correoIngresado == correoGuardado && contrasenaIngresada == contrasenaGuardada)
            {
                Preferences.Set("IsLoggedIn", true);
                DisplayAlert("Inicio de sesión", "Inicio de sesión exitoso.", "OK");
                
                Navigation.PushAsync(new MainPage());
            }
            else
            {
                DisplayAlert("Error", "Correo o contraseña incorrectos.", "OK");
            }
        }
    }
}
