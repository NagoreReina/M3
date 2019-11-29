using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TiendaMagic.Data;
using TiendaMagic.Models;
using TiendaMagic.Models.ViewModels;
using TiendaMagic.Services;

namespace TiendaMagic.Controllers
{
    public class AppUserPrizesController : Controller
    {

        private readonly IAppUserPrizes _appUserPrizes;
        private readonly IRegistries _registry;
        private readonly UserManager<AppUser> _userManager;

        public AppUserPrizesController(IAppUserPrizes appUserPrizes, UserManager<AppUser> userManager, IRegistries registry)
        {
            _appUserPrizes = appUserPrizes;
            _userManager = userManager;
            _registry = registry;
        }

        // GET: AppUserPrizes
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Index()
        {
            List<Prize> prizes = await _appUserPrizes.GetPrizeAsync();
            List<AppUserPrize> userPrizes = await _appUserPrizes.GetAppUserPrizeAsync();
            UserBuyPrizeVM userBuyPrizeVM = new UserBuyPrizeVM()
            {
                Prizes = prizes,
                UserPrizes = userPrizes
            };
            return View(userBuyPrizeVM);
        }

        // GET: AppUserPrizes/Details/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: AppUserPrizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePrizeUser(int prize, string user)
        {
            Prize newPrize = _appUserPrizes.SearchForPrize(prize);
            AppUser newUser = await _userManager.FindByIdAsync(user);
            if (newUser.Points >= newPrize.Price)
            {
                newUser.Points -= newPrize.Price;
                await _userManager.UpdateAsync(newUser);
                AppUserPrize appUserPrize = new AppUserPrize()
                {
                    Prize = newPrize,
                    User = newUser
                };
                if (ModelState.IsValid)
                {
                    await _registry.CreateRegistryAsync("Buy", newPrize.Price, newUser);
                    await _appUserPrizes.CreateAppUserPrizeAsync(appUserPrize);
                    return RedirectToAction(nameof(Index));
                }
                return View(appUserPrize);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AppUserPrizes/Edit/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appUserPrize = await _appUserPrizes.GetAppUserPrizeByIdAsync(id);
            await _appUserPrizes.DeleteAppUserPrizeAsync(appUserPrize);
            return RedirectToAction("Index", "Queries");
        }
    }
}
