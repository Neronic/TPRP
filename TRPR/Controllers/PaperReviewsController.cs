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

        public IActionResult Index()
        {
            return View();
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