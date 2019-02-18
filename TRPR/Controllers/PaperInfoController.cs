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
    public class PaperInfoController : Controller
    {
        private readonly TRPRContext _context;

        public PaperInfoController(TRPRContext context)
        {
            _context = context;
        }

        // GET: PaperInfo
        public async Task<IActionResult> Index()
        {
            return View(await _context.PaperInfos.ToListAsync());
        }

        // GET: PaperInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paperInfo = await _context.PaperInfos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (paperInfo == null)
            {
                return NotFound();
            }

            return View(paperInfo);
        }

        // GET: PaperInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaperInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PaperTitle,PaperAbstract,PaperType,PaperLength,StatID")] PaperInfo paperInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paperInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paperInfo);
        }

        // GET: PaperInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paperInfo = await _context.PaperInfos.FindAsync(id);
            if (paperInfo == null)
            {
                return NotFound();
            }
            return View(paperInfo);
        }

        // POST: PaperInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PaperTitle,PaperAbstract,PaperType,PaperLength,StatID")] PaperInfo paperInfo)
        {
            if (id != paperInfo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paperInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaperInfoExists(paperInfo.ID))
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
            return View(paperInfo);
        }

        // GET: PaperInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paperInfo = await _context.PaperInfos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (paperInfo == null)
            {
                return NotFound();
            }

            return View(paperInfo);
        }

        // POST: PaperInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paperInfo = await _context.PaperInfos.FindAsync(id);
            _context.PaperInfos.Remove(paperInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaperInfoExists(int id)
        {
            return _context.PaperInfos.Any(e => e.ID == id);
        }
    }
}
