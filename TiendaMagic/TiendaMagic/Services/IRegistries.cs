using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaMagic.Models;

namespace TiendaMagic.Services
{
    public interface IRegistries
    {
        public Task<List<Registry>> GetRegistryAsync();
        public Task<Registry> GetRegistryByIdAsync(int? id);
        public Task CreateRegistryAsync(string value, double quantity, AppUser user);
        public Task UpdateRegistryAsync(Registry registry);
        public Task DeleteRegistryAsync(Registry registry);
        public bool RegistryExists(int id);
    }
}
