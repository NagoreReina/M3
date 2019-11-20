using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Hamburgueseria.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Principales? Principal { get; set; }
        public Entrantes? Entrante { get; set; }
        public Postres? Postre { get; set; }
        public double Precio { get; set; }

    }
}
