using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TRPR.Data;
using TRPR.Models;
using TRPR.Utilities;

namespace TRPR.Controllers
{
    public class ExpertisesController : Controller
    {
        private readonly TRPRContext _context;

        public ExpertisesController(TRPRContext context)
        {
            _context = context;
        }

        // GET: Expertises
        public async Task<IActionResult> Index(int? page)
        {
            var expertises = _context.Expertises;

            int pageSize = 50;//Change as required
            var pagedData = await PaginatedList<Expertise>.CreateAsync(expertises.AsNoTracking(), page ?? 1, pageSize);

            return View(pagedData);
        }

        // GET: Expertises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expertise = await _context.Expertises
                .FirstOrDefaultAsync(m => m.ID == id);
            if (expertise == null)
            {
                return NotFound();
            }

            return View(expertise);
        }

        // GET: Expertises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Expertises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ExpName")] Expertise expertise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expertise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expertise);
        }

        // GET: Expertises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expertise = await _context.Expertises.FindAsync(id);
            if (expertise == null)
            {
                return NotFound();
            }
            return View(expertise);
        }

        // POST: Expertises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ExpName")] Expertise expertise)
        {
            if (id != expertise.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expertise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpertiseExists(expertise.ID))
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
            return View(expertise);
        }

        // GET: Expertises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expertise = await _context.Expertises
                .FirstOrDefaultAsync(m => m.ID == id);
            if (expertise == null)
            {
                return NotFound();
            }

            return View(expertise);
        }

        // POST: Expertises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expertise = await _context.Expertises.FindAsync(id);
            _context.Expertises.Remove(expertise);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpertiseExists(int id)
        {
            return _context.Expertises.Any(e => e.ID == id);
        }
    }
}
