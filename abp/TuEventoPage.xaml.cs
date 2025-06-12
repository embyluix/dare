using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace abp
{
    public partial class TuEventoPage : ContentPage
    {
        const string ComentarioKey = "comentario_guardado";

        public TuEventoPage()
        {
            InitializeComponent();

            // Cargar datos desde Preferences
            nombreEventoLabel.Text = Preferences.Get("evento_nombre", "No especificado");
            telefonoLabel.Text = Preferences.Get("evento_telefono", "No especificado");
            donacionesLabel.Text = Preferences.Get("evento_donaciones", false) ? "Sí" : "No";
            descripcionLabel.Text = Preferences.Get("evento_descripcion", "No especificado");
            fechaLabel.Text = Preferences.Get("evento_fecha", "No especificada");
            horaLabel.Text = Preferences.Get("evento_hora", "No especificada");

            // Cargar imagen del evento desde path
            string imagenPath = Preferences.Get("evento_imagen", null);
            if (!string.IsNullOrEmpty(imagenPath) && System.IO.File.Exists(imagenPath))
            {
                eventoImagen.Source = ImageSource.FromFile(imagenPath);
            }
            else
            {
                eventoImagen.Source = "default_evento.png"; // Imagen por defecto opcional
            }

            // Cargar comentario guardado
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
    }
}
