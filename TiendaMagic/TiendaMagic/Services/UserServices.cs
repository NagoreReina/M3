using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaMagic.Data;
using TiendaMagic.Models;

namespace TiendaMagic.Services
{
    public class UserServices : IUser
    {
        private readonly ApplicationDbContext _context;

        public UserServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<AppUserPrize> GetAppUserPrizes(string id)
        {
            return _context.AppUserPrize.Include(x => x.Prize).Where(x => x.User.Id == id).ToList();
        }
    }
}
