using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TiendaMagic.Data;
using TiendaMagic.Models;
using TiendaMagic.Services;

namespace TiendaMagic.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RegistriesController : Controller
    {
        private readonly IRegistries _registries;

        public RegistriesController(IRegistries registries)
        {
            _registries = registries;
        }

        // GET: Registries
        public async Task<IActionResult> Index()
        {
            return View(await _registries.GetRegistryAsync());
        }

        // GET: Registries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registry = await _registries.GetRegistryByIdAsync(id);
            if (registry == null)
            {
                return NotFound();
            }

            return View(registry);
        }

        // GET: Registries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Registries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Value,Quantity")] Registry registry)
        {
            if (ModelState.IsValid)
            {
                await _registries.CreateRegistryAsync(registry);
                return RedirectToAction(nameof(Index));
            }
            return View(registry);
        }

        // GET: Registries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registry = await _registries.GetRegistryByIdAsync(id);
            if (registry == null)
            {
                return NotFound();
            }
            return View(registry);
        }

        // POST: Registries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Value,Quantity")] Registry registry)
        {
            if (id != registry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _registries.UpdateRegistryAsync(registry);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_registries.RegistryExists(registry.Id))
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
            return View(registry);
        }

        // GET: Registries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registry = await _registries.GetRegistryByIdAsync(id);
            if (registry == null)
            {
                return NotFound();
            }

            return View(registry);
        }

        // POST: Registries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registry = await _registries.GetRegistryByIdAsync(id);
            await _registries.DeleteRegistryAsync(registry);
            return RedirectToAction(nameof(Index));
        }

    }
}
