using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace abp
{
    public partial class NotificacionesPage : ContentPage
    {
        public ObservableCollection<Notificacion> Notificaciones { get; set; }
        public ICommand ToggleNotificacionesCommand { get; set; }

        public NotificacionesPage()
        {
            InitializeComponent();

            ToggleNotificacionesCommand = new Command<Notificacion>(AlternarNotificaciones);

            Notificaciones = new ObservableCollection<Notificacion>
            {
                new Notificacion { Nombre = "Rodrigo Dayan", Imagen = "https://cdn3.iconfinder.com/data/icons/business-avatar-1/512/3_avatar-512.png" },
                new Notificacion { Nombre = "Luis Daniel", Imagen = "https://cdn-icons-png.flaticon.com/512/147/147142.png" },
                new Notificacion { Nombre = "Juan David", Imagen = "https://cdn.iconscout.com/icon/free/png-256/free-boy-avatar-icon-download-in-svg-png-gif-file-formats--male-schoolboy-guy-youngster-avatars-flat-circle-pack-people-icons-1129037.png" },
                new Notificacion { Nombre = "Joel Garza", Imagen = "https://cdn.iconscout.com/icon/free/png-256/free-avatar-367-456319.png" },
                new Notificacion { Nombre = "Leonardo Dayan", Imagen = "https://cdn-icons-png.flaticon.com/512/6858/6858504.png" }
            };

            BindingContext = this;
        }

        void AlternarNotificaciones(Notificacion noti)
        {
            noti.NotificacionesActivas = !noti.NotificacionesActivas;

            // Refresca el ítem en la UI
            int index = Notificaciones.IndexOf(noti);
            Notificaciones.Remove(noti);
            Notificaciones.Insert(index, noti);
        }

        async void OnBackTapped(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }

    public class Notificacion
    {
        public string Nombre { get; set; }
        public string Imagen { get; set; }

        public bool NotificacionesActivas
        {
            get => Preferences.Get(Nombre, true); // true por defecto
            set => Preferences.Set(Nombre, value);
        }

        public string IconoCampana => NotificacionesActivas ? "https://images.icon-icons.com/1863/PNG/512/notifications-active_118870.png" : " https://images.icon-icons.com/2065/PNG/512/notifications_icon_124898.png";
    }
}
