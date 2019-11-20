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
    public class EntrantesController : Controller
    {
        private readonly HamburgueseriaContext _context;

        public EntrantesController(HamburgueseriaContext context)
        {
            _context = context;
        }

        // GET: Entrantes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Entrantes.ToListAsync());
        }

        // GET: Entrantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrantes = await _context.Entrantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entrantes == null)
            {
                return NotFound();
            }

            return View(entrantes);
        }

        // GET: Entrantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Entrantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Ingredientes,Imagen,Precio")] Entrantes entrantes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entrantes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entrantes);
        }

        // GET: Entrantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrantes = await _context.Entrantes.FindAsync(id);
            if (entrantes == null)
            {
                return NotFound();
            }
            return View(entrantes);
        }

        // POST: Entrantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Ingredientes,Imagen,Precio")] Entrantes entrantes)
        {
            if (id != entrantes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entrantes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntrantesExists(entrantes.Id))
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
            return View(entrantes);
        }

        // GET: Entrantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrantes = await _context.Entrantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entrantes == null)
            {
                return NotFound();
            }

            return View(entrantes);
        }

        // POST: Entrantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entrantes = await _context.Entrantes.FindAsync(id);
            _context.Entrantes.Remove(entrantes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntrantesExists(int id)
        {
            return _context.Entrantes.Any(e => e.Id == id);
        }
    }
}
