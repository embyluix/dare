using Xamarin.Forms;

namespace abp.Models
{
    public class Evento
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public bool AceptaDonaciones { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string ImagenBase64 { get; set; } // Solo se guarda como texto Base64

        // Nueva propiedad para la imagen convertida
        [Newtonsoft.Json.JsonIgnore] // Ignorar en la serialización JSON
        public ImageSource Imagen { get; set; }
    }
}
