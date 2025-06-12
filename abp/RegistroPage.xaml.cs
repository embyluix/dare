using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace abp
{
    public partial class RegistroPage : ContentPage
    {
        public RegistroPage()
        {
            InitializeComponent();
        }

        private void OnRegistrarClicked(object sender, EventArgs e)
        {
            // Guardar datos en Preferences
            Preferences.Set("Nombre", entryNombre.Text);
            Preferences.Set("Apellido", entryApellido.Text);
            Preferences.Set("FechaNacimiento", datePickerNacimiento.Date.ToString("yyyy-MM-dd"));
            Preferences.Set("Telefono", entryTelefono.Text);
            Preferences.Set("Correo", entryCorreo.Text);
            Preferences.Set("Contrasena", entryContrasena.Text);
            Preferences.Set("Descripcion", entryDescripcion.Text);

            DisplayAlert("Registro", "Datos guardados exitosamente.", "OK");
        }
    }
}
