using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaMagic.Models;

namespace TiendaMagic.Services
{
    public interface IAppUserPrizes
    {
        public Task<List<AppUserPrize>> GetAppUserPrizeAsync();
        public Task<AppUserPrize> GetAppUserPrizeByIdAsync(int? id);
        public Task CreateAppUserPrizeAsync(AppUserPrize userPrize);
        public Task UpdateAppUserPrizeAsync(AppUserPrize userPrize);
        public Task DeleteAppUserPrizeAsync(AppUserPrize userPrize);

        public bool AppUserPrizeExists(int id);
    }
}
