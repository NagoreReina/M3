using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaMagic.Models
{
    public class Prize
    {
        public int Id { get; set; }
        public DateTime DateOfExpiry { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public int Price { get; set; } //Int por que se compra con puntos
        public List<AppUserPrize> AppUserPrizes { get; set; }

    }
}
