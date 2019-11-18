using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VideoClubOp.Models;

    public class VideoClubOpContext : DbContext
    {
        public VideoClubOpContext (DbContextOptions<VideoClubOpContext> options)
            : base(options)
        {
        }

        public DbSet<VideoClubOp.Models.Film> Film { get; set; }

        public DbSet<VideoClubOp.Models.User> User { get; set; }

        public DbSet<VideoClubOp.Models.UserFilm> UserFilm { get; set; }
    }
