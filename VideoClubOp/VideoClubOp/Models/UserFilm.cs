using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoClubOp.Models
{
    public class UserFilm
    {
        public int Id { get; set; }
        public DateTime DateRental { get; set; }
        public DateTime? DateReturn { get; set; }
        public User User { get; set; }
        public Film Film { get; set; }
    }
}
