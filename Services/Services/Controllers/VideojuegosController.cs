using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Models;
using Services.Services;

namespace Services.Controllers
{
    public class VideojuegosController : Controller
    {
        private readonly IVideojuegos _videojuegosServices;

        public VideojuegosController(IVideojuegos videojuegosServices)
        {
            _videojuegosServices = videojuegosServices;
        }

        // GET: Videojuegos
        public async Task<IActionResult> Index()
        {
            return View(await _videojuegosServices.GetVideojuegos());
        }

        // GET: Videojuegos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videojuego = await _videojuegosServices.GetVideojuegoById(id);
            if (videojuego == null)
            {
                return NotFound();
            }

            return View(videojuego);
        }

        // GET: Videojuegos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Videojuegos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Genero,FechaPublicacion")] Videojuego videojuego)
        {
            if (ModelState.IsValid)
            {
                await _videojuegosServices.CreateVideojuegoAsync(videojuego);
                return RedirectToAction(nameof(Index));
            }
            return View(videojuego);
        }

        // GET: Videojuegos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videojuego = await _videojuegosServices.GetVideojuegoById(id);
            if (videojuego == null)
            {
                return NotFound();
            }
            return View(videojuego);
        }

        // POST: Videojuegos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Genero,FechaPublicacion")] Videojuego videojuego)
        {
            if (id != videojuego.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _videojuegosServices.UpdateVideojuego(videojuego);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_videojuegosServices.VideojuegoExists(videojuego.Id))
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
            return View(videojuego);
        }

        // GET: Videojuegos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videojuego = await _videojuegosServices.GetVideojuegoById(id);
            if (videojuego == null)
            {
                return NotFound();
            }

            return View(videojuego);
        }

        // POST: Videojuegos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var videojuego = await _videojuegosServices.GetVideojuegoById(id);
            await _videojuegosServices.DeleteVideojuego(videojuego);
            return RedirectToAction(nameof(Index));
        }
    }
}
