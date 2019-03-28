using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TRPR.Data;
using TRPR.Models;
using TRPR.Utilities;
using TRPR.ViewModels;

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
        public async Task<IActionResult> Index(string SearchString, string SearchEmail, int? InstituteID, int? ExpertiseID, int? page, string sortDirection, string actionButton, string sortField = "FullName")
        {
            PopulateDropDownLists();
            ViewData["ExpertiseID"] = new SelectList(_context.Expertises.OrderBy(p => p.ExpName), "ID", "ExpName");
            ViewData["Filtering"] = "";

            var researcher = from r in _context.Researchers
                .Include(ri => ri.Institutes)
                .Include(r => r.ResearchExpertises)
                .ThenInclude(re => re.Expertise)
                select r;

            int pageSize = 20;//Change as required
            var pagedData = await PaginatedList<Researcher>.CreateAsync(researcher.AsNoTracking(), page ?? 1, pageSize);

            if (InstituteID.HasValue)
            {
                researcher = researcher.Where(p => p.InstituteID == InstituteID);
                ViewData["Filtering"] = " in";
            }
            if (ExpertiseID.HasValue)
            {
                researcher = researcher.Where(p => p.ResearchExpertises.Any(c => c.ExpertiseID == ExpertiseID));
                ViewData["Filtering"] = " in";
            }
            if (!String.IsNullOrEmpty(SearchString))
            {
                researcher = researcher.Where(p => p.ResLast.ToUpper().Contains(SearchString.ToUpper())
                                       || p.ResFirst.ToUpper().Contains(SearchString.ToUpper()));
                ViewData["Filtering"] = " in";
            }
            if (!String.IsNullOrEmpty(SearchEmail))
            {
                researcher = researcher.Where(p => p.ResEmail.ToUpper().Contains(SearchEmail.ToUpper()));
                ViewData["Filtering"] = " in";
            }

            //Before we sort, see if we have called for a change of filtering or sorting
            if (!String.IsNullOrEmpty(actionButton)) //Form Submitted so lets sort!
            {
                page = 1;//Reset page to start
                if (actionButton != "Filter")//Change of sort is requested
                {
                    if (actionButton == sortField) //Reverse order on same field
                    {
                        sortDirection = String.IsNullOrEmpty(sortDirection) ? "desc" : "";
                    }
                    sortField = actionButton;//Sort by the button clicked
                }
            }
            //Now we know which field and direction to sort by, but a Switch is hard to use for 2 criteria
            //so we will use an if() structure instead.
            if (sortField == "Email")
            {
                if (String.IsNullOrEmpty(sortDirection))
                {
                    researcher = researcher
                        .OrderBy(p => p.ResEmail);
                }
                else
                {
                    researcher = researcher
                        .OrderByDescending(p => p.ResEmail);
                }
            }
            else //Sorting by FullName - the default sort order
            {
                if (String.IsNullOrEmpty(sortDirection))
                {
                    researcher = researcher
                        .OrderBy(p => p.ResLast)
                        .ThenBy(p => p.ResFirst);
                }
                else
                {
                    researcher = researcher
                        .OrderByDescending(p => p.ResLast)
                        .ThenByDescending(p => p.ResFirst);
                }
            }
            //Set sort for next time
            ViewData["sortField"] = sortField;
            ViewData["sortDirection"] = sortDirection;

            return View(pagedData);
        }

        // GET: Researchers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var researcher = await _context.Researchers
                .Include(ri => ri.Institutes)
                .Include(r => r.ResearchExpertises)
                .ThenInclude(re => re.Expertise)
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
            Researcher researcher = new Researcher();
            PopulateAssignedExpertiseData(researcher);
            PopulateDropDownLists();
            return View();
        }

        // POST: Researchers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ResTitle,ResFirst,ResMiddle,ResLast,ResEmail,ResBio,IntituteID")] Researcher researcher, string[] selectedOptions)
        {
            try
            {
                UpdateResearcherExpertises(selectedOptions, researcher);
                if (ModelState.IsValid)
                {
                    _context.Add(researcher);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes after multiple attempts. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateAssignedExpertiseData(researcher);
            PopulateDropDownLists();
            return View(researcher);
        }

        // GET: Researchers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var researcher = await _context.Researchers
                .Include(r => r.Institutes)
                .Include(r => r.ResearchExpertises)
                .ThenInclude(re => re.Expertise)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (researcher == null)
            {
                return NotFound();
            }
            PopulateAssignedExpertiseData(researcher);
            PopulateDropDownLists();
            return View(researcher);
        }

        // POST: Researchers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string[] selectedOptions)
        {
            var researcherToUpdate = await _context.Researchers
                .Include(ri => ri.Institutes)
                .Include(r => r.ResearchExpertises)
                .ThenInclude(re => re.Expertise)
                .SingleOrDefaultAsync(m => m.ID == id);

            if (researcherToUpdate == null)
            {
                return NotFound();
            }

            UpdateResearcherExpertises(selectedOptions, researcherToUpdate);


            if (await TryUpdateModelAsync<Researcher>(researcherToUpdate, "", 
                r => r.TitleID, r => r.ResFirst, r => r.ResMiddle, r => r.ResLast, r => r.ResBio, r => r.ResEmail, r => r.InstituteID))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    ModelState.AddModelError("", "Unable to save changes after multiple attempts. Try again, and if the problem persists, see your system administrator.");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResearcherExists(researcherToUpdate.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }
            PopulateAssignedExpertiseData(researcherToUpdate);
            PopulateDropDownLists();
            return View(researcherToUpdate);
        }

        // GET: Researchers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var researcher = await _context.Researchers
                .Include(r => r.Institutes)
                .Include(r => r.ResearchExpertises)
                .ThenInclude(re => re.Expertise)
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
            try
            {
                _context.Researchers.Remove(researcher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ResearcherExists(int id)
        {
            return _context.Researchers.Any(e => e.ID == id);
        }

        private SelectList TitleSelectList(int? id)
        {
            var dQuery = from d in _context.Titles
                         orderby d.Name
                         select d;
            return new SelectList(dQuery, "ID", "Name", id);
        }

        private SelectList InstituteSelectList(int? id)
        {
            var dQuery = from d in _context.Institutes
                         orderby d.InstName
                         select d;
            return new SelectList(dQuery, "ID", "InstName", id);
        }

        private void PopulateDropDownLists(Researcher researcher = null)
        {
            ViewData["TitleID"] = TitleSelectList(researcher?.TitleID);
            ViewData["InstituteID"] = InstituteSelectList(researcher?.InstituteID);
        }

        private void PopulateAssignedExpertiseData(Researcher researcher)
        {
            var allExpertises = _context.Expertises;
            var resExpertises = new HashSet<int>(researcher.ResearchExpertises.Select(b => b.ExpertiseID));
            var selected = new List<ExpertiseVM>();
            var available = new List<ExpertiseVM>();
            foreach (var s in allExpertises)
            {
                if (resExpertises.Contains(s.ID))
                {
                    selected.Add(new ExpertiseVM
                    {
                        ExpertiseID = s.ID,
                        ExpName = s.ExpName
                    });
                }
                else
                {
                    available.Add(new ExpertiseVM
                    {
                        ExpertiseID = s.ID,
                        ExpName = s.ExpName
                    });
                }
            }

            ViewData["selOpts"] = new MultiSelectList(selected.OrderBy(s => s.ExpName), "ExpertiseID", "ExpName");
            ViewData["availOpts"] = new MultiSelectList(available.OrderBy(s => s.ExpName), "ExpertiseID", "ExpName");
        }

        private void UpdateResearcherExpertises(string[] selectedOptions, Researcher researcherToUpdate)
        {
            if (selectedOptions == null)
            {
                researcherToUpdate.ResearchExpertises = new List<ResearchExpertise>();
                return;
            }

            var selectedOptionsHS = new HashSet<string>(selectedOptions);
            var resExpertises = new HashSet<int>(researcherToUpdate.ResearchExpertises.Select(b => b.ExpertiseID));
            foreach (var s in _context.Expertises)
            {
                if (selectedOptionsHS.Contains(s.ID.ToString()))
                {
                    if (!resExpertises.Contains(s.ID))
                    {
                        researcherToUpdate.ResearchExpertises.Add(new ResearchExpertise
                        {
                            ExpertiseID = s.ID,
                            ResearcherID = researcherToUpdate.ID
                        });
                    }
                }
                else
                {
                    if (resExpertises.Contains(s.ID))
                    {
                        ResearchExpertise specToRemove = researcherToUpdate.ResearchExpertises.SingleOrDefault(d => d.ExpertiseID == s.ID);
                        _context.Remove(specToRemove);
                    }
                }
            }
        }
    }
}
