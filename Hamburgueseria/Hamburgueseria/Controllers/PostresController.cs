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
    public class PostresController : Controller
    {
        private readonly HamburgueseriaContext _context;

        public PostresController(HamburgueseriaContext context)
        {
            _context = context;
        }

        // GET: Postres
        public async Task<IActionResult> Index()
        {
            return View(await _context.Postres.ToListAsync());
        }

        // GET: Postres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postres = await _context.Postres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postres == null)
            {
                return NotFound();
            }

            return View(postres);
        }

        // GET: Postres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Postres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Ingredientes,Imagen,Precio")] Postres postres)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postres);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postres);
        }

        // GET: Postres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postres = await _context.Postres.FindAsync(id);
            if (postres == null)
            {
                return NotFound();
            }
            return View(postres);
        }

        // POST: Postres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Ingredientes,Imagen,Precio")] Postres postres)
        {
            if (id != postres.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postres);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostresExists(postres.Id))
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
            return View(postres);
        }

        // GET: Postres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postres = await _context.Postres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postres == null)
            {
                return NotFound();
            }

            return View(postres);
        }

        // POST: Postres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postres = await _context.Postres.FindAsync(id);
            _context.Postres.Remove(postres);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostresExists(int id)
        {
            return _context.Postres.Any(e => e.Id == id);
        }
    }
}
