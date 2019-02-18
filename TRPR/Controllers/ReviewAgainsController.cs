using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TRPR.Data;
using TRPR.Models;

namespace TRPR.Controllers
{
    public class ReviewAgainsController : Controller
    {
        private readonly TRPRContext _context;

        public ReviewAgainsController(TRPRContext context)
        {
            _context = context;
        }

        // GET: ReviewAgains
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReviewAgains.ToListAsync());
        }

        // GET: ReviewAgains/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewAgain = await _context.ReviewAgains
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reviewAgain == null)
            {
                return NotFound();
            }

            return View(reviewAgain);
        }

        // GET: ReviewAgains/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReviewAgains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ReSponse")] ReviewAgain reviewAgain)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reviewAgain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reviewAgain);
        }

        // GET: ReviewAgains/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewAgain = await _context.ReviewAgains.FindAsync(id);
            if (reviewAgain == null)
            {
                return NotFound();
            }
            return View(reviewAgain);
        }

        // POST: ReviewAgains/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ReSponse")] ReviewAgain reviewAgain)
        {
            if (id != reviewAgain.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reviewAgain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewAgainExists(reviewAgain.ID))
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
            return View(reviewAgain);
        }

        // GET: ReviewAgains/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewAgain = await _context.ReviewAgains
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reviewAgain == null)
            {
                return NotFound();
            }

            return View(reviewAgain);
        }

        // POST: ReviewAgains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reviewAgain = await _context.ReviewAgains.FindAsync(id);
            _context.ReviewAgains.Remove(reviewAgain);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewAgainExists(int id)
        {
            return _context.ReviewAgains.Any(e => e.ID == id);
        }
    }
}
