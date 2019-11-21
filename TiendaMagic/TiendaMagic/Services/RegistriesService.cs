using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaMagic.Data;
using TiendaMagic.Models;

namespace TiendaMagic.Services
{
    public class RegistriesService : IRegistries
    {
        private readonly ApplicationDbContext _context;
        public RegistriesService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateRegistryAsync(Registry registry)
        {
            await _context.AddAsync(registry);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRegistryAsync(Registry registry)
        {
            _context.Registry.Remove(registry);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Registry>> GetRegistryAsync()
        {
            return await _context.Registry.ToListAsync();
        }

        public async Task<Registry> GetRegistryByIdAsync(int? id)
        {
            return await _context.Registry.FindAsync(id);
        }

        public bool RegistryExists(int id)
        {
            return _context.Registry.Any(e => e.Id == id);
        }

        public async Task UpdateRegistryAsync(Registry registry)
        {
            _context.Update(registry);
            await _context.SaveChangesAsync();
        }
    }
}
