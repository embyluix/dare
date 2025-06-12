using Xamarin.Essentials;
using Xamarin.Forms;

namespace abp
{
    public partial class PruebaPage : ContentPage
    {
        public PruebaPage()
        {
            InitializeComponent();

            // Cargar datos desde Preferences
            labelNombre.Text = $"Nombre: {Preferences.Get("Nombre", "No definido")}";
            labelApellido.Text = $"Apellido: {Preferences.Get("Apellido", "No definido")}";
            labelFecha.Text = $"Fecha de Nacimiento: {Preferences.Get("FechaNacimiento", "No definida")}";
            labelTelefono.Text = $"Teléfono: {Preferences.Get("Telefono", "No definido")}";
            labelCorreo.Text = $"Correo: {Preferences.Get("Correo", "No definido")}";
            labelContrasena.Text = $"Contraseña: {Preferences.Get("Contrasena", "No definida")}";
            labelDescripcion.Text = $"Descripción: {Preferences.Get("Descripcion", "No definida")}";
        }
    }
}
