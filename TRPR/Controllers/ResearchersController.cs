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
    public class ResearchersController : Controller
    {
        private readonly TRPRContext _context;

        public ResearchersController(TRPRContext context)
        {
            _context = context;
        }

        // GET: Researchers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Researchers.ToListAsync());
        }

        // GET: Researchers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var researcher = await _context.Researchers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (researcher == null)
            {
                return NotFound();
            }

            return View(researcher);
        }

        // GET: Researchers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Researchers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ResTitle,ResFirst,ResMiddle,ResLast,ResEmail,ResBio")] Researcher researcher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(researcher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(researcher);
        }

        // GET: Researchers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var researcher = await _context.Researchers.FindAsync(id);
            if (researcher == null)
            {
                return NotFound();
            }
            return View(researcher);
        }

        // POST: Researchers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ResTitle,ResFirst,ResMiddle,ResLast,ResEmail,ResBio")] Researcher researcher)
        {
            if (id != researcher.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(researcher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResearcherExists(researcher.ID))
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
            return View(researcher);
        }

        // GET: Researchers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var researcher = await _context.Researchers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (researcher == null)
            {
                return NotFound();
            }

            return View(researcher);
        }

        // POST: Researchers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var researcher = await _context.Researchers.FindAsync(id);
            _context.Researchers.Remove(researcher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResearcherExists(int id)
        {
            return _context.Researchers.Any(e => e.ID == id);
        }
    }
}
