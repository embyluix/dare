using System;
using System.Collections.Generic;
using System.Text;

namespace abp.Models
{
    public class Donacion
    {
        public string Destino { get; set; }
        public string Monto { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Imagen { get; set; }
        public string Cuenta { get; set; }
    }
}
