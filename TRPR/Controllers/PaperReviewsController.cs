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
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;


namespace TRPR.Controllers
{
    public class PaperReviewsController : Controller
    {
        private readonly TRPRContext _context;

        public PaperReviewsController(TRPRContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? PaperInfoID, string SearchRes, string SearchTitle, int? CreatedOn, int? page, string sortDirection, string actionButton, string sortField = "CreatedOn")
        {
            if (!PaperInfoID.HasValue)
            {
                return RedirectToAction("Index", "PaperInfos");
            }

            PopulateDropDownLists();
                       ViewData["Filtering"] = "";

            var revs = from a in _context.ReviewAssigns
                       .Include(a => a.Recommend)
                       .Include(a => a.PaperInfo)
                        where a.PaperInfoID == PaperInfoID.GetValueOrDefault()
                        select a;

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
            //so we will use an if () structure instead.
            if (sortField == "Paper Title")//Sorting by Status
            {
                if (String.IsNullOrEmpty(sortDirection))
                {
                    revs = revs
                        .OrderBy(p => p.PaperInfo.PaperTitle);
                }
                else
                {
                    revs = revs
                       .OrderByDescending(p => p.PaperInfo.PaperTitle);
                }
            }
            else if (sortField == "Researcher")//Sorting by Status
            {
                if (String.IsNullOrEmpty(sortDirection))
                {
                    revs = revs
                        .OrderBy(p => p.Researcher.FullName);
                }
                else
                {
                    revs = revs
                       .OrderByDescending(p => p.Researcher.FullName);
                }
            }
            else
            {
                if (String.IsNullOrEmpty(sortDirection))
                {
                    revs = revs
                        .OrderByDescending(p => p.CreatedOn);
                }
                else
                {
                    revs = revs
                       .OrderBy(p => p.CreatedOn);
                }
            }

            //Set sort for next time
            ViewData["sortField"] = sortField;
            ViewData["sortDirection"] = sortDirection;

            int pageSize = 20;//Change as required
            var pagedData = await PaginatedList<ReviewAssign>.CreateAsync(revs.AsNoTracking(), page ?? 1, pageSize);

            //Now get the MASTER record, the patient, so it can be displayed at the top of the screen
            //PaperInfo paperInfo = _context.PaperInfos
            //   .Include(p => p.PaperTitle)
            //    .Include(p => p.PaperAbstract)
            //.Include(p => p.AuthoredPapers)
            //.ThenInclude(pc => pc.)
            //    .Where(p => p.ID == PaperInfoID.GetValueOrDefault()).FirstOrDefault();
            //ViewBag.PaperInfo = paperInfo;

            return View(pagedData);

           

        }

        //GET: Reviews/Add
        public IActionResult Add(int? PaperInfoID, string PaperTitle)
        {
            if (!PaperInfoID.HasValue)
            {
                return RedirectToAction("Index", "PaperInfos");
            }
            ViewData["PaperTitle"] = PaperTitle;

            ReviewAssign a = new ReviewAssign()
            {
                PaperInfoID = PaperInfoID.GetValueOrDefault()
            };

            PopulateDropDownLists();
            return View(a);
        }

        //POST: Reviews/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("ID, PaperInfoID, ResearcherID, RolesID, RevContentReview, RevKeywordReview, RevLengthReview, RevFormatReview, RevCitationReview, EiCComment, AuthorComment, RecommendID, ReviewAgainID")] ReviewAssign reviewAssign, string[] selectedOptions, string PaperTitle)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(reviewAssign);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", new { reviewAssign.PaperInfoID });
                }

            }

            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes");
            }
            PopulateDropDownLists(reviewAssign);
            ViewData["PaperTitle"] = PaperTitle;
            return View(reviewAssign);
        }

        // GET: PaperReviews/Edit/5
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewAssign = await _context.ReviewAssigns
                .Include(a => a.PaperInfo)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (reviewAssign == null)
            {
                return NotFound();
            }

            PopulateDropDownLists(reviewAssign);
            return View(reviewAssign);
        }

        //GET: PaperReviews/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id)
        {
            var reviewAssignToUpdate = await _context.ReviewAssigns
                .Include(a => a.PaperInfo)
                .FirstOrDefaultAsync(m => m.ID == id);

            //Check you got the record
            if (reviewAssignToUpdate == null)
            {
                return NotFound();
            }

            //Tey Updating with the new values
            if (await TryUpdateModelAsync<ReviewAssign>(reviewAssignToUpdate, "",
             s => s.PaperInfoID, s => s.ResearcherID, s => s.RoleID, s => s.RevContentReview, s => s.RevKeywordReview, s => s.RevLengthReview,
                s => s.RevFormatReview, s => s.RevCitationReview, s => s.EiCComment, s => s.AuthorComment, s => s.RecommendID, s => s.ReviewAgainID))

                try
                {
                    _context.Update(reviewAssignToUpdate);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", new { reviewAssignToUpdate.PaperInfoID });

                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewAssignExists(reviewAssignToUpdate.ID))
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
                    ModelState.AddModelError("", "Unable to save changes");
                }
            PopulateDropDownLists(reviewAssignToUpdate);
            return View(reviewAssignToUpdate);
        }





        private SelectList RoleSelectList(int? id)
        {
            var dQuery = from d in _context.Roles
                         orderby d.RoleTitle
                         select d;
            return new SelectList(dQuery, "ID", "RoleTitle", id);
        }

        private SelectList ResearcherSelectList(int? id)
        {
            var dQuery = from d in _context.Researchers
                         orderby d.ResLast, d.ResFirst
                         select d;
            return new SelectList(dQuery, "ID", "FullName", id);
        }

        private SelectList PaperSelectList(int? id)
        {
            var dQuery = from d in _context.PaperInfos
                         orderby d.PaperTitle
                         select d;
            return new SelectList(dQuery, "ID", "PaperTitle", id);
        }

        private SelectList AgainSelectList(int? id)
        {
            var dQuery = from d in _context.ReviewAgains
                         orderby d.ReSponse
                         select d;
            return new SelectList(dQuery, "ID", "ReSponse", id);
        }

        private SelectList RecSelectList(int? id)
        {
            var dQuery = from d in _context.Recommends
                         orderby d.RecTitle
                         select d;
            return new SelectList(dQuery, "ID", "RecTitle", id);
        }

        private void PopulateDropDownLists(ReviewAssign reviewAssign = null)
        {
            ViewData["RoleID"] = RoleSelectList(reviewAssign?.RoleID);
            ViewData["ResearcherID"] = ResearcherSelectList(reviewAssign?.ResearcherID);
            ViewData["PaperInfoID"] = PaperSelectList(reviewAssign?.PaperInfoID);
            ViewData["RecommendID"] = RecSelectList(reviewAssign?.RecommendID);
            ViewData["ReviewAgainID"] = AgainSelectList(reviewAssign?.ReviewAgainID);
        }

        private bool ReviewAssignExists(int id)
        {
            return _context.ReviewAssigns.Any(e => e.ID == id);
        }
    }
}