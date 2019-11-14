using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkExample.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkExample.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Obra> Obras { get; set; }
        public DbSet<Autobiografia> Autobiografias { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ObraCategoria> ObraCategorias { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
