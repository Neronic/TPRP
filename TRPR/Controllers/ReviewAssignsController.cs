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
    public class ReviewAssignsController : Controller
    {
        private readonly TRPRContext _context;

        public ReviewAssignsController(TRPRContext context)
        {
            _context = context;
        }

        // GET: ReviewAssigns
        public async Task<IActionResult> Index()
        {
            var tRPRContext = _context.ReviewAssigns.Include(r => r.Roles);
            return View(await tRPRContext.ToListAsync());
        }

        // GET: ReviewAssigns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewAssign = await _context.ReviewAssigns
                .Include(r => r.Roles)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reviewAssign == null)
            {
                return NotFound();
            }

            return View(reviewAssign);
        }

        // GET: ReviewAssigns/Create
        public IActionResult Create()
        {
            ViewData["RoleID"] = new SelectList(_context.Roles, "ID", "RoleTitle");
            return View();
        }

        // POST: ReviewAssigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PaperID,ResID,RoleID,RevContentReview,RevKeywordReview,RevLengthReview,RevFormatReview,RevCitationReview,RecID,ReRevID")] ReviewAssign reviewAssign)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reviewAssign);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleID"] = new SelectList(_context.Roles, "ID", "RoleTitle", reviewAssign.RoleID);
            return View(reviewAssign);
        }

        // GET: ReviewAssigns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewAssign = await _context.ReviewAssigns.FindAsync(id);
            if (reviewAssign == null)
            {
                return NotFound();
            }
            ViewData["RoleID"] = new SelectList(_context.Roles, "ID", "RoleTitle", reviewAssign.RoleID);
            return View(reviewAssign);
        }

        // POST: ReviewAssigns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PaperID,ResID,RoleID,RevContentReview,RevKeywordReview,RevLengthReview,RevFormatReview,RevCitationReview,RecID,ReRevID")] ReviewAssign reviewAssign)
        {
            if (id != reviewAssign.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reviewAssign);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewAssignExists(reviewAssign.ID))
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
            ViewData["RoleID"] = new SelectList(_context.Roles, "ID", "RoleTitle", reviewAssign.RoleID);
            return View(reviewAssign);
        }

        // GET: ReviewAssigns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewAssign = await _context.ReviewAssigns
                .Include(r => r.Roles)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reviewAssign == null)
            {
                return NotFound();
            }

            return View(reviewAssign);
        }

        // POST: ReviewAssigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reviewAssign = await _context.ReviewAssigns.FindAsync(id);
            _context.ReviewAssigns.Remove(reviewAssign);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewAssignExists(int id)
        {
            return _context.ReviewAssigns.Any(e => e.ID == id);
        }
    }
}
