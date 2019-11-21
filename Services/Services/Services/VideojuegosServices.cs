using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Models;

namespace Services.Services
{
    public class VideojuegosServices : IVideojuegos
    {
        private readonly Context _context;
        public VideojuegosServices(Context context)
        {
            _context = context;
        }
        public async Task CreateVideojuegoAsync(Videojuego videojuego)
        {
           await _context.AddAsync(videojuego);
           
        }

        public void DeleteVideojuego(Videojuego videojuego)
        {
            throw new NotImplementedException();
        }

        public Videojuego GetVideojuegoById(int id)
        {
            throw new NotImplementedException();
        }

        public List<IVideojuegos> GetVideojuegos()
        {
            throw new NotImplementedException();
        }

        public void UpdateVideojuego(Videojuego videojuego)
        {
            throw new NotImplementedException();
        }

        public bool VideojuegoExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
