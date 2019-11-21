using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaMagic.Models
{
    public class Registry
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [MaxLength(6)]
        public string Value { get; set; } //Points or Money
        public double Quantity { get; set; }
        public AppUser User { get; set; }
    }
}
