using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstExercise.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public double Precio { get; set; }
        public DateTime FechaCaducidad { get; set; }
        public string Imagen { get; set; }
    }
}
