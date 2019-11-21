﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TiendaMagic.Data;
using TiendaMagic.Models;

namespace TiendaMagic.Controllers
{
    public class AppUserPrizesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppUserPrizesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AppUserPrizes
        public async Task<IActionResult> Index()
        {
            return View(await _context.AppUserPrize.ToListAsync());
        }

        // GET: AppUserPrizes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUserPrize = await _context.AppUserPrize
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appUserPrize == null)
            {
                return NotFound();
            }

            return View(appUserPrize);
        }

        // GET: AppUserPrizes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AppUserPrizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] AppUserPrize appUserPrize)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appUserPrize);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appUserPrize);
        }

        // GET: AppUserPrizes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUserPrize = await _context.AppUserPrize.FindAsync(id);
            if (appUserPrize == null)
            {
                return NotFound();
            }
            return View(appUserPrize);
        }

        // POST: AppUserPrizes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] AppUserPrize appUserPrize)
        {
            if (id != appUserPrize.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appUserPrize);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppUserPrizeExists(appUserPrize.Id))
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
            return View(appUserPrize);
        }

        // GET: AppUserPrizes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUserPrize = await _context.AppUserPrize
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appUserPrize == null)
            {
                return NotFound();
            }

            return View(appUserPrize);
        }

        // POST: AppUserPrizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appUserPrize = await _context.AppUserPrize.FindAsync(id);
            _context.AppUserPrize.Remove(appUserPrize);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppUserPrizeExists(int id)
        {
            return _context.AppUserPrize.Any(e => e.Id == id);
        }
    }
}
