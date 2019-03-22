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
        public async Task<IActionResult> Index(int? PaperInfoID, int? ResearcherID, int? RoleID)
        {
            var reviewAssigns = _context.ReviewAssigns
                .Include(ra => ra.Roles)
                .Include(ra => ra.Researcher)
                .ThenInclude(r => r.ResearchExpertises)
                .ThenInclude(re => re.Expertise)
                .Include(r => r.PaperInfo);
            return View(await reviewAssigns.ToListAsync());
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
                .Include(ra => ra.Researcher)
                .ThenInclude(r => r.ResearchExpertises)
                .ThenInclude(re => re.Expertise)
                .Include(r => r.PaperInfo)
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
            PopulateDropDownLists();
            PopulateExpertiseDropDownList();
            return View();
        }

        // POST: ReviewAssigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PaperInfoID,ResearcherID,RoleID,RevContentReview,RevKeywordReview,RevLengthReview,RevFormatReview,RevCitationReview,RecommendID,ReviewAgainID")] ReviewAssign reviewAssign)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(reviewAssign);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                 ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            PopulateDropDownLists();
            PopulateExpertiseDropDownList();
            return View(reviewAssign);
        }

        // GET: ReviewAssigns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewAssign = await _context.ReviewAssigns
                .Include(r => r.Roles)
                .Include(ra => ra.Researcher)
                .ThenInclude(r => r.ResearchExpertises)
                .ThenInclude(re => re.Expertise)
                .Include(r => r.PaperInfo)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reviewAssign == null)
            {
                return NotFound();
            }
            PopulateDropDownLists();
            return View(reviewAssign);
        }

        // POST: ReviewAssigns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)//, [Bind("ID,PaperInfoID,ResearcherID,RoleID,RevContentReview,RevKeywordReview,RevLengthReview,RevFormatReview,RevCitationReview,RecommendID,ReviewAgainID")] ReviewAssign reviewAssign)
        {
            var reviewToUpdate = await _context.ReviewAssigns
                .Include(r => r.Roles)
                .Include(ra => ra.Researcher)
                .ThenInclude(r => r.ResearchExpertises)
                .ThenInclude(re => re.Expertise)
                .Include(r => r.PaperInfo)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reviewToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<ReviewAssign>(reviewToUpdate, "",
                s => s.PaperInfoID, s => s.ResearcherID, s => s.RoleID, s => s.RevContentReview, s => s.RevKeywordReview, s => s.RevLengthReview, 
                s => s.RevFormatReview, s => s.RevCitationReview, s => s.RecommendID, s => s.ReviewAgainID))
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
                    if (!ReviewAssignExists(reviewToUpdate.ID))
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
            PopulateDropDownLists();
            return View(reviewToUpdate);
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
                .Include(ra => ra.Researcher)
                .ThenInclude(r => r.ResearchExpertises)
                .ThenInclude(re => re.Expertise)
                .Include(r => r.PaperInfo)
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
            var reviewAssign = await _context.ReviewAssigns
                .Include(r => r.Roles)
                .Include(ra => ra.Researcher)
                .ThenInclude(r => r.ResearchExpertises)
                .ThenInclude(re => re.Expertise)
                .Include(r => r.PaperInfo)
                .FirstOrDefaultAsync(m => m.ID == id);

            try
            {
                _context.ReviewAssigns.Remove(reviewAssign);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(reviewAssign);
        }

        //public PartialViewResult GetViewerPartial(int? id)
        //{
        //    string fileBase64 = "";//For our Byte[] converted to Base64 String
        //    string downLink = "";//In case the file cannot be displayed
        //    string MimeType = "";//So the partial view can decide what to do with the file

        //    var theFile = _context.Files.Include(f => f.FileContent).Where(f => f.ID == id.GetValueOrDefault()).SingleOrDefault();
        //    if (theFile != null)
        //    {
        //        fileBase64 = Convert.ToBase64String(theFile.FileContent.Content);
        //        MimeType = theFile?.FileContent.MimeType;
        //        downLink = "<a href='/files/download/" + theFile.ID + "' title='Download: " + theFile.Description + "'>" + theFile.FileName + "</a>";
        //    }
        //    ViewData["MimeType"] = MimeType;
        //    ViewData["fileBase64"] = fileBase64;
        //    ViewData["downloadLink"] = downLink;
        //    return PartialView("_pdfViewwer");
        //}




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

        private void PopulateExpertiseDropDownList()
        {
            var dQuery = from d in _context.Expertises
                         orderby d.ExpName
                         select d;
            ViewData["ExpertiseID"] = new SelectList(dQuery, "ID", "ExpName");
        }

        [HttpGet]
        public JsonResult GetResearcherByExpertise(int? id)
        {
            var dQuery = from d in _context.Researchers.Include(z => z.ResearchExpertises)
                         select d;
            if (id.HasValue)
            {
                dQuery = dQuery.Where(d => d.ResearchExpertises.Any(s => s.ExpertiseID == id));
            }
            return Json(new SelectList(dQuery
                .OrderBy(d => d.ResLast)
                .ThenBy(d => d.ResFirst), "ID", "FullName"));
        }

        private bool ReviewAssignExists(int id)
        {
            return _context.ReviewAssigns.Any(e => e.ID == id);
        }
    }
}
