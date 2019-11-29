using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaMagic.Models.ViewModels
{
    public class UserBuyPrizeVM
    {
        public List<Prize> Prizes { get; set; }
        public List<AppUserPrize> UserPrizes { get; set; }
    }
}
