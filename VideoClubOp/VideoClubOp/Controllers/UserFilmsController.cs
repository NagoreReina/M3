using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VideoClubOp.Models;

namespace VideoClubOp.Controllers
{
    public class UserFilmsController : Controller
    {
        private readonly VideoClubOpContext _context;

        public UserFilmsController(VideoClubOpContext context)
        {
            _context = context;
        }

        // GET: UserFilms
        public async Task<IActionResult> Index(string DateReturn, string title)
        {
            List<UserFilm> userFilms = await _context.UserFilm.Include(x => x.Film).ToListAsync();
            if (!String.IsNullOrEmpty(title))
            {
                userFilms = userFilms.Where(x => x.Film.Title.ToLower().Contains(title.ToLower())).ToList();
            }
            if (!String.IsNullOrEmpty(DateReturn))
            {
                if (DateReturn == "Returned")
                {
                    userFilms = userFilms.Where(x => x.DateReturn != null).ToList();
                }
                if (DateReturn == "Null")
                {
                    userFilms = userFilms.Where(x => x.DateReturn == null).ToList();
                }
            }
            return View(userFilms);
        }

        // GET: UserFilms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFilm = await _context.UserFilm.Include(x => x.Film)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userFilm == null)
            {
                return NotFound();
            }

            return View(userFilm);
        }

        // GET: UserFilms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserFilms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateRental,DateReturn")] UserFilm userFilm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userFilm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userFilm);
        }

        public async Task<IActionResult> Rent(int filmId)
        {
            Film rentedFilm = await _context.Film.FindAsync(filmId);
            rentedFilm.Rented = true;
            _context.Update(rentedFilm);
            await _context.SaveChangesAsync();

            UserFilm newRent = new UserFilm()
            {
                DateRental = DateTime.Now,
                Film = rentedFilm,
                User = await _context.User.FindAsync(1)
            };
            _context.Add(newRent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Return(int id)
        {
            UserFilm userFilm = await _context.UserFilm.Include(x=>x.Film).FirstOrDefaultAsync(x=>x.Id==id);
            userFilm.DateReturn = DateTime.Now;
            _context.Update(userFilm);
            await _context.SaveChangesAsync();
            Film rentedFilm = await _context.Film.FindAsync(userFilm.Film.Id);
            rentedFilm.Rented = false;
            _context.Update(userFilm.Film);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: UserFilms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFilm = await _context.UserFilm.FindAsync(id);
            if (userFilm == null)
            {
                return NotFound();
            }
            return View(userFilm);
        }

        // POST: UserFilms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateRental,DateReturn")] UserFilm userFilm)
        {
            if (id != userFilm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userFilm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserFilmExists(userFilm.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userFilm);
        }

        // GET: UserFilms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFilm = await _context.UserFilm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userFilm == null)
            {
                return NotFound();
            }

            return View(userFilm);
        }

        // POST: UserFilms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userFilm = await _context.UserFilm.FindAsync(id);
            _context.UserFilm.Remove(userFilm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserFilmExists(int id)
        {
            return _context.UserFilm.Any(e => e.Id == id);
        }
    }
}
