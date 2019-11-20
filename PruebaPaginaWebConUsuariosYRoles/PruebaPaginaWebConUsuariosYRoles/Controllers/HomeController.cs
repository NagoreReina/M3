using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaPaginaWebConUsuariosYRoles.Models;

namespace PruebaPaginaWebConUsuariosYRoles.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(ILogger<HomeController> logger, 
            SignInManager<AppUser> signInManager, 
            UserManager<AppUser> userManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return View();
            }
            return NotFound();
        }
        public async Task<IActionResult> Administrador()
        {
            if (_signInManager.IsSignedIn(User))
            {
                AppUser user = await _userManager.GetUserAsync(User);

                if (await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    return View();
                }
            }
            return NotFound();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
