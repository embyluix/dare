using abp1;
using DAREApp;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace abp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            bool isLoggedIn = Preferences.Get("IsLoggedIn", false);

            if (isLoggedIn)
                MainPage = new NavigationPage(new MainPage());  // Ya está logueado
            else
                MainPage = new NavigationPage(new InicioSesionPage()); // Necesita loguearse
        }
    }
}
