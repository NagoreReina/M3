using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaMagic.Models;

namespace TiendaMagic.Services
{
    public interface IPrizes
    {
        public Task<List<Prize>> GetPrizeAsync();
        public Task<Prize> GetPrizeByIdAsync(int? id);
        public Task CreatePrizeAsync(Prize prize);
        public Task UpdatePrizeAsync(Prize prize);
        public Task DeletePrizeAsync(Prize prize);
        public bool PrizeExists(int id);
        public void DeleteFromAppUserPrizes(int prizeId);
    }
}
