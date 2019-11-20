using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hamburgueseria.Models
{
    public class Principales
    {
        public int Id { get; set; }
        [MaxLength(25)]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Ingredientes { get; set; }
        public string Imagen { get; set; }
        public double Precio { get; set; }
    }
}
