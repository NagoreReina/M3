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
    public class QueriesController : Controller
    {
        private readonly IQueries _queries;

        public QueriesController(IQueries queries)
        {
            _queries = queries;

        }
        // GET: Queries
        public async Task<IActionResult> Index()
        {
            return View(await _queries.GetQueryAsync());
        }

        // GET: Queries/Details/5
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: Queries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Text,Resolved")] Query query)
        {
            if (ModelState.IsValid)
            {
                await _queries.CreateQueryAsync(query);
                return RedirectToAction(nameof(Index));
            }
            return View(query);
        }

        // GET: Queries/Edit/5
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var query = await _queries.GetQueryByIdAsync(id);
            await _queries.DeleteQueryAsync(query);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ChangeToResolved(int id)
        {
            Query query = await _queries.GetQueryByIdAsync(id);
            query.Resolved = true;
            await _queries.UpdateQueryAsync(query);
            return RedirectToAction(nameof(Index));
        }

    }
}
