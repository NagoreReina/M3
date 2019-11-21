using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TiendaMagic.Models;

namespace TiendaMagic.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TiendaMagic.Models.Prize> Prize { get; set; }
        public DbSet<TiendaMagic.Models.Registry> Registry { get; set; }
        public DbSet<TiendaMagic.Models.Query> Query { get; set; }
        public DbSet<TiendaMagic.Models.AppUserPrize> AppUserPrize { get; set; }
    }
}
