using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hamburgueseria.Models;

    public class HamburgueseriaContext : DbContext
    {
        public HamburgueseriaContext (DbContextOptions<HamburgueseriaContext> options)
            : base(options)
        {
        }

        public DbSet<Hamburgueseria.Models.Menu> Menu { get; set; }

        public DbSet<Hamburgueseria.Models.Entrantes> Entrantes { get; set; }

        public DbSet<Hamburgueseria.Models.Principales> Principales { get; set; }

        public DbSet<Hamburgueseria.Models.Postres> Postres { get; set; }
    }
