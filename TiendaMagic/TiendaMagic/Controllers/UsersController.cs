using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using TiendaMagic.Models;

namespace TiendaMagic.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public List<AppUser> appUsers = new List<AppUser>();

        public UsersController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> IndexAsync()
        {
            appUsers = (await _userManager.GetUsersInRoleAsync("Client")).ToList(); 
            return View(appUsers);
        }
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id")] AppUser user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _userManager.UpdateAsync(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
        public async Task<IActionResult> ChangePoints(string? id, int points)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            user.Points += points;
            await _userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ChangeMoney(string? id, double money)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            user.Money += money;
            await _userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Index));
        }
    }
}