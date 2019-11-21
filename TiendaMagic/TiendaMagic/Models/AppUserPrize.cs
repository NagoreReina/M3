using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaMagic.Models
{
    public class AppUserPrize
    {
        public int Id { get; set; }
        public AppUser User { get; set; }
        public Prize Prize { get; set; }
    }
}
