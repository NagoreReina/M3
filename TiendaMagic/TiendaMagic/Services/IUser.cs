using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaMagic.Models;

namespace TiendaMagic.Services
{
    public interface IUser
    {
        public List<AppUserPrize> GetAppUserPrizes(string id);
    }
}
