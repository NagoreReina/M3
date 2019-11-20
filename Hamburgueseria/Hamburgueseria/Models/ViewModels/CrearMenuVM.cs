using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hamburgueseria.Models.ViewModels
{
    public class CrearMenuVM
    {
        public DateTime Fecha { get; set; }
        public List<Entrantes> Entrantes { get; set; }
        public List<Principales> Principales { get; set; }
        public List<Postres> Postres { get; set; }
        public Menu Menu { get; set; }
        public double PrecioFinal { get; set; }
    }
}
