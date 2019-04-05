using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class ResearcherProfileController : Controller
    {
        private readonly TRPRContext _context;

        public ResearcherProfileController(TRPRContext context)
        {
            _context = context;
        }

        // GET: ResearcherProfile
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Details));
        }

        // GET: ResearcherProfile/Details/5
        public async Task<IActionResult> Details()
        {
            var researcher = await _context.Researchers
                .Include(r => r.Institutes)
                .Include(r => r.ResearchExpertises)
                .ThenInclude(re => re.Expertise)
                .Include(r => r.Institutes)
                .Include(r => r.Title)
                .Where(c => c.ResEmail == User.Identity.Name)
                .FirstOrDefaultAsync();

            if (researcher == null)
            {
                return RedirectToAction(nameof(Create));
            }

            return View(researcher);
        }

        // GET: ResearcherProfile/Create
        public IActionResult Create()
        {
            Researcher researcher = new Researcher();
            PopulateAssignedExpertiseData(researcher);
            PopulateDropDownLists();
            return View();
        }

        // POST: ResearcherProfile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID, TitleID,ResFirst,ResLast,ResBio,InstituteID, ResEmail")] Researcher researcher, string[] selectedOptions)
        {
            researcher.ResEmail = User.Identity.Name;
            try
            {
                UpdateResearcherExpertises(selectedOptions, researcher);
                if (ModelState.IsValid)
                {
                    _context.Add(researcher);
                    await _context.SaveChangesAsync();
                    UpdateUserNameCookie(researcher.FullName);
                    return RedirectToAction(nameof(Details));
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

        // GET: EmployeeProfile/Edit/5
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
                .Include(r => r.Institutes)
                .Include(r => r.Title)
                .Where(c => c.ResEmail == User.Identity.Name)
                .FirstOrDefaultAsync();
            if (researcher == null)
            {
                return NotFound();
            }
            return View(researcher);
        }

        // POST: ResearcherProfile/Edit/5
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
                .Include(r => r.Institutes)
                .Include(r => r.Title)
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
                    _context.Update(researcherToUpdate);
                    await _context.SaveChangesAsync();
                    UpdateUserNameCookie(researcherToUpdate.ResEmail);
                    return RedirectToAction(nameof(Index));
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    ModelState.AddModelError("", "Unable to save changes after multiple attempts. Try again, and if the problem persists, see your system administrator.");
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

        private void UpdateUserNameCookie(string userName)
        {
            CookieHelper.CookieSet(HttpContext, "userName", userName, 960);
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
