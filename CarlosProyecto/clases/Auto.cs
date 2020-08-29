using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarlosProyecto.clases
{
    public class Auto
    {
        public int Id { get; set; }
        public string TipoAutomovil { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string TipoCombustible { get; set; }
        public decimal Cilindraje { get; set; }
        public string Transmision { get; set; }
        public string Condiciones { get; set; }
        public string Atributos { get; set; }
    }
}