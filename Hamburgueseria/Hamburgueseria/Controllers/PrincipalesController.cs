using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hamburgueseria.Models;

namespace Hamburgueseria.Controllers
{
    public class PrincipalesController : Controller
    {
        private readonly HamburgueseriaContext _context;

        public PrincipalesController(HamburgueseriaContext context)
        {
            _context = context;
        }

        // GET: Principales
        public async Task<IActionResult> Index()
        {
            return View(await _context.Principales.ToListAsync());
        }

        // GET: Principales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var principales = await _context.Principales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (principales == null)
            {
                return NotFound();
            }

            return View(principales);
        }

        // GET: Principales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Principales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Ingredientes,Imagen,Precio")] Principales principales)
        {
            if (ModelState.IsValid)
            {
                _context.Add(principales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(principales);
        }

        // GET: Principales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var principales = await _context.Principales.FindAsync(id);
            if (principales == null)
            {
                return NotFound();
            }
            return View(principales);
        }

        // POST: Principales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Ingredientes,Imagen,Precio")] Principales principales)
        {
            if (id != principales.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(principales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrincipalesExists(principales.Id))
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
            return View(principales);
        }

        // GET: Principales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var principales = await _context.Principales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (principales == null)
            {
                return NotFound();
            }

            return View(principales);
        }

        // POST: Principales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var principales = await _context.Principales.FindAsync(id);
            _context.Principales.Remove(principales);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrincipalesExists(int id)
        {
            return _context.Principales.Any(e => e.Id == id);
        }
    }
}
