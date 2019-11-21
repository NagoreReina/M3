using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface IVideojuegos
    {
        public List<IVideojuegos> GetVideojuegos();
        public Videojuego GetVideojuegoById(int id);
        public Task CreateVideojuegoAsync(Videojuego videojuego);
        public void UpdateVideojuego(Videojuego videojuego);
        public void DeleteVideojuego(Videojuego videojuego);
        public bool VideojuegoExists(int id);
    }
}
