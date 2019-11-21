using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TiendaMagic.Data;
using TiendaMagic.Models;
using TiendaMagic.Services;

namespace TiendaMagic.Controllers
{
    public class AppUserPrizesController : Controller
    {

        private readonly IAppUserPrizes _appUserPrizes;

        public AppUserPrizesController(IAppUserPrizes appUserPrizes)
        {
            _appUserPrizes = appUserPrizes;
        }

        // GET: AppUserPrizes
        public async Task<IActionResult> Index()
        {
            return View(await _appUserPrizes.GetAppUserPrizeAsync());
        }

        // GET: AppUserPrizes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUserPrize = await _appUserPrizes.GetAppUserPrizeByIdAsync(id);
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
                await _appUserPrizes.CreateAppUserPrizeAsync(appUserPrize);
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

            var appUserPrize = await _appUserPrizes.GetAppUserPrizeByIdAsync(id);
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
                    await _appUserPrizes.UpdateAppUserPrizeAsync(appUserPrize);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_appUserPrizes.AppUserPrizeExists(appUserPrize.Id))
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

            var appUserPrize = await _appUserPrizes.GetAppUserPrizeByIdAsync(id);
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
            var appUserPrize = await _appUserPrizes.GetAppUserPrizeByIdAsync(id);
            await _appUserPrizes.DeleteAppUserPrizeAsync(appUserPrize);
            return RedirectToAction(nameof(Index));
        }
    }
}
