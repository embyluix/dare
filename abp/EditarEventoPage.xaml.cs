using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Essentials;
using Xamarin.Forms;
using abp.Models;

namespace abp
{
    public partial class EditarEventoPage : ContentPage
    {
        private Evento eventoOriginal;
        private string imagenBase64;

        public EditarEventoPage(Evento evento)
        {
            InitializeComponent();
            eventoOriginal = evento;

            // Prellenar campos
            nombreEntry.Text = evento.Nombre;
            telefonoEntry.Text = evento.Telefono;
            donacionesCheckBox.IsChecked = evento.AceptaDonaciones;
            descripcionEditor.Text = evento.Descripcion;
            fechaPicker.Date = DateTime.Parse(evento.Fecha);
            horaPicker.Time = TimeSpan.Parse(evento.Hora);
            imagenBase64 = evento.ImagenBase64;

            if (!string.IsNullOrEmpty(imagenBase64))
            {
                byte[] imageBytes = Convert.FromBase64String(imagenBase64);
                eventoImage.Source = ImageSource.FromStream(() => new MemoryStream(imageBytes));
            }
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
                using (var memoryStream = new MemoryStream())
                {
                    file.GetStream().CopyTo(memoryStream);
                    imagenBase64 = Convert.ToBase64String(memoryStream.ToArray());
                }

                eventoImage.Source = ImageSource.FromStream(() =>
                    new MemoryStream(Convert.FromBase64String(imagenBase64)));
            }
        }
        private void OnGuardarCambiosClicked(object sender, EventArgs e)
        {
            var eventoEditado = new Evento
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

            // ✅ Cambiamos el nombre del parámetro para evitar conflicto con EventArgs e
            int index = eventos.FindIndex(ev =>
                ev.Nombre == eventoOriginal.Nombre &&
                ev.Fecha == eventoOriginal.Fecha &&
                ev.Hora == eventoOriginal.Hora);

            if (index != -1)
            {
                eventos[index] = eventoEditado;
                Preferences.Set("eventos_lista", JsonConvert.SerializeObject(eventos));
                DisplayAlert("Éxito", "Evento editado correctamente", "OK");
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Error", "No se pudo encontrar el evento para editar.", "OK");
            }
        }

    }
}
