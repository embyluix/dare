using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Essentials;
using Newtonsoft.Json;
using abp.Models;

namespace abp
{
    public partial class HistorialBancarioPage : ContentPage
    {
        public HistorialBancarioPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Cargar datos desde Preferences o precargar si no hay
            var json = Preferences.Get("historialDonaciones", "");

            if (string.IsNullOrEmpty(json))
            {
                // Precargar datos si es la primera vez
                var listaDonaciones = new List<Donacion>
                {
                    new Donacion
                    {
                        Destino = "Alimentos food",
                        Monto = "$1000",
                        Fecha = "30/05/25",
                        Hora = "5:30pm",
                        Imagen = "donacion1.jpg",
                        Cuenta = "************"
                    },
                    new Donacion
                    {
                        Destino = "Alimentos para niños",
                        Monto = "$10000",
                        Fecha = "26/05/25",
                        Hora = "5:30am",
                        Imagen = "donacion2.jpg",
                        Cuenta = "************"
                    }
                };

                json = JsonConvert.SerializeObject(listaDonaciones);
                Preferences.Set("historialDonaciones", json);
            }

            MostrarDonaciones();
        }

        private void MostrarDonaciones()
        {
            DonacionesLayout.Children.Clear();

            var json = Preferences.Get("historialDonaciones", "[]");
            var donaciones = JsonConvert.DeserializeObject<List<Donacion>>(json);

            foreach (var donacion in donaciones)
            {
                var frame = new Frame
                {
                    BackgroundColor = Color.White,
                    CornerRadius = 10,
                    Padding = 10,
                    HasShadow = true,
                    Content = new StackLayout
                    {
                        Spacing = 5,
                        Children =
                        {
                            new Label { Text = $"🧾 Donación a: {donacion.Destino}", FontAttributes = FontAttributes.Bold, FontSize = 16 },
                            new Label { Text = $"💵 Total: {donacion.Monto}", FontSize = 14 },
                            new StackLayout
                            {
                                Orientation = StackOrientation.Horizontal,
                                Children =
                                {
                                    new Label { Text = $"📅 {donacion.Fecha}" },
                                    new Label { Text = $"🕒 {donacion.Hora}", Margin = new Thickness(10,0,0,0) }
                                }
                            },
                            new Image { Source = donacion.Imagen, HeightRequest = 100, Aspect = Aspect.AspectFill },
                            new Label { Text = $"Cuenta: {donacion.Cuenta}", FontSize = 12, FontAttributes = FontAttributes.Italic }
                        }
                    }
                };

                DonacionesLayout.Children.Add(frame);
            }
        }
    }
}
