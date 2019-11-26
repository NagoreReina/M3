using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaMagic.Data;
using TiendaMagic.Models;

namespace TiendaMagic.Services
{
    public class PrizesService : IPrizes
    {
        private readonly ApplicationDbContext _context;
        public PrizesService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreatePrizeAsync(Prize prize)
        {
            await _context.AddAsync(prize);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePrizeAsync(Prize prize)
        {
            _context.Prize.Remove(prize);
            await _context.SaveChangesAsync();
        }
        public void DeleteFromAppUserPrizes (int prizeId)
        {
            List<AppUserPrize> appUserPrizes = (_context.AppUserPrize.Include(x=>x.Prize).Where(x => x.Prize.Id == prizeId)).ToList();
            foreach(AppUserPrize userPrize in appUserPrizes)
            {
                _context.Remove(userPrize);
            }
        }
        public async Task<List<Prize>> GetPrizeAsync()
        {
            return await _context.Prize.ToListAsync();
        }

        public async Task<Prize> GetPrizeByIdAsync(int? id)
        {
            return await _context.Prize.FindAsync(id);
        }

        public bool PrizeExists(int id)
        {
            return _context.Prize.Any(e => e.Id == id);
        }

        public async Task UpdatePrizeAsync(Prize prize)
        {
            _context.Update(prize);
            await _context.SaveChangesAsync();
        }
    }
}
