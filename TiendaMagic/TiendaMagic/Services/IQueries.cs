using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaMagic.Models;


namespace TiendaMagic.Services
{
    public interface IQueries
    {
        public Task<List<Query>> GetQueryAsync();
        public Task<Query> GetQueryByIdAsync(int? id);
        public Task CreateQueryAsync(Query query);
        public Task UpdateQueryAsync(Query query);
        public Task DeleteQueryAsync(Query query);
        public bool QueryExists(int id);
    }
}
