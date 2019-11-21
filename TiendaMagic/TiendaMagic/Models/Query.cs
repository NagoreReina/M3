using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaMagic.Models
{
    public class Query
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public bool Resolved { get; set; }
        public AppUser User { get; set; }

    }
}
