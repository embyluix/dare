using System;
using Xamarin.Forms;
using Xamarin.Essentials;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.Collections.Generic;
using Newtonsoft.Json;
using abp.Models;
using System.IO;

namespace abp
{
    public partial class AgregarEventoPage : ContentPage
    {
        string imagenBase64 = "";

        public AgregarEventoPage()
        {
            InitializeComponent();
        }

        private async void OnSeleccionarImagenClicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("No disponible", "No se puede seleccionar imagen.", "OK");
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync();

            if (file != null)
            {
                var stream = file.GetStream();
                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    imagenBase64 = Convert.ToBase64String(memoryStream.ToArray());
                }

                eventoImage.Source = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(imagenBase64)));
            }
        }

        private void OnGuardarEventoClicked(object sender, EventArgs e)
        {
            var evento = new Evento
            {
                Nombre = nombreEntry.Text,
                Telefono = telefonoEntry.Text,
                AceptaDonaciones = donacionesCheckBox.IsChecked,
                Descripcion = descripcionEditor.Text,
                Fecha = fechaPicker.Date.ToString("yyyy-MM-dd"),
                Hora = horaPicker.Time.ToString(@"hh\:mm"),
                ImagenBase64 = imagenBase64
            };

            var json = Preferences.Get("eventos_lista", "[]");
            var eventos = JsonConvert.DeserializeObject<List<Evento>>(json);
            eventos.Add(evento);

            Preferences.Set("eventos_lista", JsonConvert.SerializeObject(eventos));

            DisplayAlert("Éxito", "Evento guardado correctamente", "OK");
            Navigation.PopAsync();
        }
    }
}
