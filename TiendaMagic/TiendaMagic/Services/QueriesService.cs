using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaMagic.Data;
using TiendaMagic.Models;

namespace TiendaMagic.Services
{
    public class QueriesService : IQueries
    {
        private readonly ApplicationDbContext _context;
        public QueriesService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateQueryAsync(Query query)
        {
            await _context.AddAsync(query);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteQueryAsync(Query query)
        {
            _context.Query.Remove(query);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Query>> GetQueryAsync()
        {
            return await _context.Query.Include(x => x.User).ToListAsync();
        }

        public async Task<Query> GetQueryByIdAsync(int? id)
        {
            return await _context.Query.Include(x => x.User).FirstOrDefaultAsync(m => m.Id == id);
        }

        public bool QueryExists(int id)
        {
            return _context.Query.Any(e => e.Id == id);
        }

        public async Task UpdateQueryAsync(Query query)
        {
            _context.Update(query);
            await _context.SaveChangesAsync();
        }
    }
}
