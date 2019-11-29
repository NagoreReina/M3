using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaMagic.Models;

namespace TiendaMagic.Services
{
    public interface IAppUserPrizes
    {
        public Task<List<Prize>> GetPrizeAsync();
        public Task<List<AppUserPrize>> GetAppUserPrizeAsync();
        public Task<AppUserPrize> GetAppUserPrizeByIdAsync(int? id);
        public Task CreateAppUserPrizeAsync(AppUserPrize userPrize);
        public Task UpdateAppUserPrizeAsync(AppUserPrize userPrize);
        public Task DeleteAppUserPrizeAsync(AppUserPrize userPrize);
        public Prize SearchForPrize(int id);
        public bool AppUserPrizeExists(int id);
    }
}
