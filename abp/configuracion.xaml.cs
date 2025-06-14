﻿using System;
using Xamarin.Forms;

namespace abp
{
    public partial class configuracion : ContentPage
    {
        public configuracion()
        {
            InitializeComponent();
        }

        private void OnBackButtonClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync(); // o PopModalAsync si lo abriste como modal
        }

        private async void OnCuentaClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PerfilPage());
        }

        private async void OnAccesibilidadClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistroPage());
        }

        private async void OnNormasClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new normas());
        }

        private  async void  OnPermisosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PruebaPage());
        }

        private void OnTemaClicked(object sender, EventArgs e)
        {
            DisplayAlert("Cambiar de Tema", "Sección Tema", "OK");
        }

        private void OnAyudaClicked(object sender, EventArgs e)
        {
            DisplayAlert("Ayuda", "Sección Ayuda", "OK");
        }
    }
}
