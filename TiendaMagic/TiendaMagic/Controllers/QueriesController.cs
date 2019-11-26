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
using TiendaMagic.Services;

namespace TiendaMagic.Controllers
{
    public class QueriesController : Controller
    {
        private readonly IQueries _queries;
        private readonly UserManager<AppUser> _userManager;

        public QueriesController(IQueries queries, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _queries = queries;

        }
        // GET: Queries
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _queries.GetQueryAsync());
        }

        // GET: Queries/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var query = await _queries.GetQueryByIdAsync(id);
            if (query == null)
            {
                return NotFound();
            }

            return View(query);
        }

        // GET: Queries/Create
        [Authorize(Roles = "Client")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Queries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Create(string id, string text, Query query)
        {
            query.Date = DateTime.Now;
            query.Resolved = false;
            AppUser user = await _userManager.FindByIdAsync(id);
            query.User = user;
            query.Text = text;
            await _queries.CreateQueryAsync(query);
            return RedirectToAction("Index", "AppUserPrizes");
        }

        // GET: Queries/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var query = await _queries.GetQueryByIdAsync(id);
            if (query == null)
            {
                return NotFound();
            }
            return View(query);
        }


        // POST: Queries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Text,Resolved")] Query query)
        {
            if (id != query.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _queries.UpdateQueryAsync(query);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_queries.QueryExists(query.Id))
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
            return View(query);
        }

        // GET: Queries/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var query = await _queries.GetQueryByIdAsync(id);
            if (query == null)
            {
                return NotFound();
            }

            return View(query);
        }

        // POST: Queries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var query = await _queries.GetQueryByIdAsync(id);
            await _queries.DeleteQueryAsync(query);

            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeToResolved(int id)
        {
            Query query = await _queries.GetQueryByIdAsync(id);
            query.Resolved = true;
            await _queries.UpdateQueryAsync(query);
            return RedirectToAction(nameof(Index));
        }

    }
}
