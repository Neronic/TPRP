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
    public class FileTypesController : Controller
    {
        private readonly TRPRContext _context;

        public FileTypesController(TRPRContext context)
        {
            _context = context;
        }

        // GET: FileTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FileTypes.ToListAsync());
        }

        // GET: FileTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileType = await _context.FileTypes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fileType == null)
            {
                return NotFound();
            }

            return View(fileType);
        }

        // GET: FileTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FileTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TypeName")] FileType fileType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fileType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fileType);
        }

        // GET: FileTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileType = await _context.FileTypes.FindAsync(id);
            if (fileType == null)
            {
                return NotFound();
            }
            return View(fileType);
        }

        // POST: FileTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TypeName")] FileType fileType)
        {
            if (id != fileType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fileType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FileTypeExists(fileType.ID))
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
            return View(fileType);
        }

        // GET: FileTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileType = await _context.FileTypes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fileType == null)
            {
                return NotFound();
            }

            return View(fileType);
        }

        // POST: FileTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fileType = await _context.FileTypes.FindAsync(id);
            _context.FileTypes.Remove(fileType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FileTypeExists(int id)
        {
            return _context.FileTypes.Any(e => e.ID == id);
        }
    }
}
