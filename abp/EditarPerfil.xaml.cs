using System;
using Xamarin.Forms;
using Xamarin.Essentials;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.IO;

namespace abp
{
    public partial class EditarPerfilPage : ContentPage
    {
        public EditarPerfilPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Cargar nombre y descripción
            NombreEntry.Text = Preferences.Get("nombreUsuario", "");
            DescripcionEditor.Text = Preferences.Get("descripcionPerfil", "");

            // Cargar imagen de perfil si existe
            var imagePath = Preferences.Get("imagenPerfil", "");
            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                ProfileImage.Source = ImageSource.FromFile(imagePath);
            else
                ProfileImage.Source = "default_profile.png"; // Usa una imagen por defecto del proyecto
        }
        //funcion para tomar una foto o elegir una de la galería
        private async void OnEditPhotoClicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            string action = await DisplayActionSheet("Cambiar foto de perfil", "Cancelar", null, "Tomar foto", "Elegir de galería");

            if (action == "Tomar foto")
            {
                if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
                {
                    var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                    {
                        SaveToAlbum = true,
                        PhotoSize = PhotoSize.Medium,
                        Directory = "PerfilFotos",
                        Name = $"perfil_{DateTime.Now:yyyyMMdd_HHmmss}.jpg"
                    });

                    if (photo != null)
                    {
                        ProfileImage.Source = ImageSource.FromFile(photo.Path);
                        Preferences.Set("imagenPerfil", photo.Path);
                    }
                }
                else
                {
                    await DisplayAlert("Error", "La cámara no está disponible", "OK");
                }
            }
            else if (action == "Elegir de galería")
            {
                var file = await CrossMedia.Current.PickPhotoAsync();
                if (file != null)
                {
                    ProfileImage.Source = ImageSource.FromFile(file.Path);
                    Preferences.Set("imagenPerfil", file.Path);
                }
            }
        }


        private async void OnGuardarClicked(object sender, EventArgs e)
        {
            Preferences.Set("nombreUsuario", NombreEntry.Text ?? "");
            Preferences.Set("descripcionPerfil", DescripcionEditor.Text ?? "");

            await DisplayAlert("Guardado", "Perfil actualizado correctamente", "OK");
            await Navigation.PopAsync(); // Vuelve a la página anterior
        }
    }
}

