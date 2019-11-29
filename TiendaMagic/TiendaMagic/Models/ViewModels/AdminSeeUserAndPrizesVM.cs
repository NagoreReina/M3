using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaMagic.Models.ViewModels
{
    public class AdminSeeUserAndPrizesVM
    {
        public AppUser User { get; set; }
        public List<AppUserPrize> UserPrizes { get; set; }
    }
}
