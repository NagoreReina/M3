using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using TiendaMagic.Models;
using Microsoft.AspNetCore.Authorization;
using TiendaMagic.Services;
using TiendaMagic.Data;
using TiendaMagic.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace TiendaMagic.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        
        private readonly IRegistries _registry;
        private readonly IUser _user;
        public List<AppUser> appUsers = new List<AppUser>();

        public UsersController(UserManager<AppUser> userManager, IRegistries registry, IUser user)
        {
            _registry = registry;
            _userManager = userManager;
            _user = user;
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
            List<AppUserPrize> appUserPrizes = _user.GetAppUserPrizes(id);
            AppUser user = await _userManager.FindByIdAsync(id);
            AdminSeeUserAndPrizesVM userAndPrizesVM = new AdminSeeUserAndPrizesVM()
            {
                User = user,
                UserPrizes = appUserPrizes
            };
            if (user == null)
            {
                return NotFound();
            }

            return View(userAndPrizesVM);
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
        public async Task<IActionResult> Edit(string id, [Bind("Id", "Name", "LastName", "Nick", "Dci", "Email", "Image", "Points", "Money","PhoneNumber")] AppUser user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }
            AppUser editUser = await _userManager.FindByIdAsync(user.Id);
            editUser.Name = user.Name;
            editUser.LastName = user.LastName;
            editUser.Dci = user.Dci;
            editUser.PhoneNumber = user.PhoneNumber;
            if (ModelState.IsValid)
            {
                await _userManager.UpdateAsync(editUser);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
        public async Task<IActionResult> ChangePoints(string id, int points)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            user.Points += points;
            await _userManager.UpdateAsync(user);
            //HAY QUE HACER UN REGISTRO
            await _registry.CreateRegistryAsync("Points", points, user);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ChangeMoney(string id, double money)
        {   
            AppUser user = await _userManager.FindByIdAsync(id);
            user.Money += money;
            await _userManager.UpdateAsync(user);
            await _registry.CreateRegistryAsync("Money", money, user);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> CreateUser(AppUser newUser)
        {
            newUser.UserName = newUser.Email;
            newUser.EmailConfirmed = true;
            newUser.Image = "userImg/1.png";
            if (ModelState.IsValid)
            {
                await _userManager.CreateAsync(newUser,"123Abc.");
                await _userManager.AddToRoleAsync(newUser, "Client");
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Create));
        }
        public async Task<IActionResult> Delete(string id)
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
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            await _userManager.RemoveFromRoleAsync(user, "Client");
            await _userManager.AddToRoleAsync(user, "Deleted");
            return RedirectToAction(nameof(Index));
        }
    }
}