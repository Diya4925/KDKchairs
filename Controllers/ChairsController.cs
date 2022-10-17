using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using chairs.Data;
using chairs.Models;

namespace chairs.Controllers
{
    public class ChairsController : Controller
    {
        private readonly chairsContext _context;

        public ChairsController(chairsContext context)
        {
            _context = context;
        }

        // GET: Chairs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Chairs.ToListAsync());
        }

        // GET: Chairs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chairs = await _context.Chairs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chairs == null)
            {
                return NotFound();
            }

            return View(chairs);
        }

        // GET: Chairs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chairs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Colour,Height,Price, Rating")] Chairs chairs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chairs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chairs);
        }

        // GET: Chairs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chairs = await _context.Chairs.FindAsync(id);
            if (chairs == null)
            {
                return NotFound();
            }
            return View(chairs);
        }

        // POST: Chairs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Colour,Height,Price")] Chairs chairs)
        {
            if (id != chairs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chairs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChairsExists(chairs.Id))
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
            return View(chairs);
        }

        // GET: Chairs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chairs = await _context.Chairs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chairs == null)
            {
                return NotFound();
            }

            return View(chairs);
        }

        // POST: Chairs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chairs = await _context.Chairs.FindAsync(id);
            _context.Chairs.Remove(chairs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChairsExists(int id)
        {
            return _context.Chairs.Any(e => e.Id == id);
        }
    }
}
