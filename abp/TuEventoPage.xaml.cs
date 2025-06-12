using System;
using abp.Models;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace abp
{
    public partial class TuEventoPage : ContentPage
    {
        const string ComentarioKey = "comentario_guardado";
        private Evento eventoActual; // ✅ Campo para usar en la edición

        public TuEventoPage(Evento evento)
        {
            InitializeComponent();
            eventoActual = evento; // ✅ Guardamos el evento para luego pasarlo a la página de edición

            // Llenar campos con los datos del evento recibido
            nombreEventoLabel.Text = evento.Nombre;
            telefonoLabel.Text = evento.Telefono;
            donacionesLabel.Text = evento.AceptaDonaciones ? "Sí" : "No";
            descripcionLabel.Text = evento.Descripcion;
            fechaLabel.Text = evento.Fecha;
            horaLabel.Text = evento.Hora;

            // Cargar imagen (base64)
            if (!string.IsNullOrEmpty(evento.ImagenBase64))
            {
                byte[] imageBytes = Convert.FromBase64String(evento.ImagenBase64);
                eventoImagen.Source = ImageSource.FromStream(() => new MemoryStream(imageBytes));
            }
            else
            {
                eventoImagen.Source = "default_evento.png"; // Imagen por defecto
            }

            // Comentario guardado
            string comentarioGuardado = Preferences.Get(ComentarioKey, string.Empty);
            if (!string.IsNullOrEmpty(comentarioGuardado))
            {
                comentariosLabel.Text = comentarioGuardado;
            }
        }

        private void OnEnviarComentarioClicked(object sender, EventArgs e)
        {
            string nuevoComentario = comentarioEntry.Text?.Trim();
            if (!string.IsNullOrEmpty(nuevoComentario))
            {
                Preferences.Set(ComentarioKey, nuevoComentario);
                comentariosLabel.Text = nuevoComentario;
                comentarioEntry.Text = string.Empty;

                DisplayAlert("Comentario guardado", "Tu comentario ha sido guardado", "OK");
            }
        }

        private async void editarclick(object sender, EventArgs e)
        {
            // ✅ Ir a la página de edición con el evento actual
            await Navigation.PushAsync(new EditarEventoPage(eventoActual));
        }
    }
}
