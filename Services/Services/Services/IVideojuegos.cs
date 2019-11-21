using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface IVideojuegos
    {
        public Task<List<Videojuego>> GetVideojuegos();
        public Task<Videojuego> GetVideojuegoById(int? id);
        public Task CreateVideojuegoAsync(Videojuego videojuego);
        public Task UpdateVideojuego(Videojuego videojuego);
        public Task DeleteVideojuego(Videojuego videojuego);
        public bool VideojuegoExists(int id);
    }
}
