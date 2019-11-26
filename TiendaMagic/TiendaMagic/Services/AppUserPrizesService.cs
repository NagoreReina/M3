using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaMagic.Data;
using TiendaMagic.Models;

namespace TiendaMagic.Services
{
    public class AppUserPrizesService : IAppUserPrizes
    {
        private readonly ApplicationDbContext _context;
        public AppUserPrizesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AppUserPrizeExists(int id)
        {
            return _context.AppUserPrize.Include(x=>x.Prize).Any(e => e.Id == id);
        }

        public async Task CreateAppUserPrizeAsync(AppUserPrize userPrize)
        {
            await _context.AddAsync(userPrize);
            await _context.SaveChangesAsync();
        }
        public Prize SearchForPrize(int id)
        {
            return _context.Prize.Find(id);
        }

        public async Task DeleteAppUserPrizeAsync(AppUserPrize userPrize)
        {
            _context.AppUserPrize.Remove(userPrize);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Prize>> GetAppUserPrizeAsync()
        {
            return await _context.Prize.ToListAsync();
        }

        public async Task<AppUserPrize> GetAppUserPrizeByIdAsync(int? id)
        {
            return await _context.AppUserPrize.FindAsync(id);
        }

        public async Task UpdateAppUserPrizeAsync(AppUserPrize userPrize)
        {
            _context.Update(userPrize);
            await _context.SaveChangesAsync();
        }
    }
}
