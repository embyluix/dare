using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using abp.Models;

namespace abp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MostrarEventosPage : ContentPage
    {
        private List<Evento> listaEventos;

        public MostrarEventosPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Obtener la lista de eventos guardados en Preferences
            var eventosJson = Preferences.Get("eventos_lista", "[]");

            // Deserializar la lista
            listaEventos = JsonConvert.DeserializeObject<List<Evento>>(eventosJson);

            if (listaEventos == null)
                listaEventos = new List<Evento>();

            // Convertir la imagen base64 a ImageSource para cada evento
            foreach (var evento in listaEventos)
            {
                if (!string.IsNullOrEmpty(evento.ImagenBase64))
                {
                    byte[] imageBytes = Convert.FromBase64String(evento.ImagenBase64);
                    evento.Imagen = ImageSource.FromStream(() => new MemoryStream(imageBytes));
                }
                else
                {
                    evento.Imagen = null; // O puedes poner una imagen por defecto aquí
                }
            }

            // Asignar la lista al CollectionView
            eventosCollectionView.ItemsSource = listaEventos;
        }

        private async void OnEditarClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var eventoSeleccionado = button?.BindingContext as Evento;

            if (eventoSeleccionado != null)
            {
                // Aquí puedes navegar a una página para editar el evento seleccionado
                await DisplayAlert("Editar", $"Editar evento: {eventoSeleccionado.Nombre}", "OK");
                // Ejemplo: await Navigation.PushAsync(new EditarEventoPage(eventoSeleccionado));
            }
        }


    }
}
