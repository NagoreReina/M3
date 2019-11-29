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
    public class PrizesController : Controller
    {
        private readonly IPrizes _prizes;

        public PrizesController(IPrizes prizes)
        {
            _prizes = prizes;
        }

        // GET: Prizes

        public async Task<IActionResult> Index()
        {
            return View(await _prizes.GetPrizeAsync());
        }

        // GET: Prizes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prize = await _prizes.GetPrizeByIdAsync(id);
            if (prize == null)
            {
                return NotFound();
            }

            return View(prize);
        }

        // GET: Prizes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateOfExpiry,Title,Text,Image,Price")] Prize prize)
        {
            //ESTO DE MOMENTO PARA QUE SALGA ALGO--------------------
            //prize.Image = "/Img/6.png";

            if (ModelState.IsValid)
            {
                await _prizes.CreatePrizeAsync(prize);
                return RedirectToAction(nameof(Index));
            }
            return View(prize);
        }

        // GET: Prizes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prize = await _prizes.GetPrizeByIdAsync(id);
            if (prize == null)
            {
                return NotFound();
            }
            return View(prize);
        }

        // POST: Prizes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateOfExpiry,Title,Text,Image,Price")] Prize prize)
        {
            if (id != prize.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _prizes.UpdatePrizeAsync(prize);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_prizes.PrizeExists(prize.Id))
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
            return View(prize);
        }

        // GET: Prizes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prize = await _prizes.GetPrizeByIdAsync(id);
            if (prize == null)
            {
                return NotFound();
            }

            return View(prize);
        }

        // POST: Prizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prize = await _prizes.GetPrizeByIdAsync(id);
            _prizes.DeleteFromAppUserPrizes(id);
            await _prizes.DeletePrizeAsync(prize);
            return RedirectToAction(nameof(Index));
        }

    }
}
