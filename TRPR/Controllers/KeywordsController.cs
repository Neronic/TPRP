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
    public class KeywordsController : Controller
    {
        private readonly TRPRContext _context;

        public KeywordsController(TRPRContext context)
        {
            _context = context;
        }

        // GET: Keywords
        public async Task<IActionResult> Index()
        {
            return View(await _context.Keywords.ToListAsync());
        }

        // GET: Keywords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keyword = await _context.Keywords
                .FirstOrDefaultAsync(m => m.ID == id);
            if (keyword == null)
            {
                return NotFound();
            }

            return View(keyword);
        }

        // GET: Keywords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Keywords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,KeyWord")] Keyword keyword)
        {
            if (ModelState.IsValid)
            {
                _context.Add(keyword);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(keyword);
        }

        // GET: Keywords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keyword = await _context.Keywords.FindAsync(id);
            if (keyword == null)
            {
                return NotFound();
            }
            return View(keyword);
        }

        // POST: Keywords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,KeyWord")] Keyword keyword)
        {
            if (id != keyword.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(keyword);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KeywordExists(keyword.ID))
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
            return View(keyword);
        }

        // GET: Keywords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keyword = await _context.Keywords
                .FirstOrDefaultAsync(m => m.ID == id);
            if (keyword == null)
            {
                return NotFound();
            }

            return View(keyword);
        }

        // POST: Keywords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var keyword = await _context.Keywords.FindAsync(id);
            _context.Keywords.Remove(keyword);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KeywordExists(int id)
        {
            return _context.Keywords.Any(e => e.ID == id);
        }
    }
}
