using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaMagic.Models
{
    public class AppUser:IdentityUser
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(20)]
        public string Nick { get; set; }
        public string Image { get; set; }
        [MaxLength(10)]
        [MinLength(10)]
        public string Dci { get; set; }
        public int Points { get; set; }
        public double Money { get; set; }
        public List<Query> Queries { get; set; }
        public List<Registry> Registries { get; set; }
        public List<AppUserPrize> AppUserPrizes { get; set; }
    }
}
