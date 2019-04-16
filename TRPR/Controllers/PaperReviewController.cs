using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TRPR.Data;
using TRPR.Models;
using TRPR.Utilities;

namespace TRPR.Controllers
{
    public class PaperReviewController : Controller
    {
        private readonly TRPRContext _context;

        public PaperReviewController(TRPRContext context)
        {
            _context = context;
        }

        // GET: Reviews
        public async Task<IActionResult> Index(int PaperInfoID, int? ResearcherID, int? RoleID, string SearchString)
        {
            //if (!PaperInfoID.HasValue)
            //{
            //    return RedirectToAction("Index", "PaperInfos");
            //}
            //PopulateDropDownLists();
            ViewData["Filtering"] = "";

            var revs = from a in _context.ReviewAssigns.Include(a => a.PaperInfoID).Include(a => a.RecommendID)
                        where a.PaperInfoID == PaperInfoID
                        select a;

            

            //Now get the MASTER record, the patient, so it can be displayed at the top of the screen
            PaperInfo paper = _context.PaperInfos
                .Include(p => p.ID)
                .Include(p => p.Status)
                .Include(pc => pc.PaperTitle)
                .Where(p => p.ID == PaperInfoID).FirstOrDefault();
            ViewBag.PaperInfo = paper;
            return View();
        }

        //// GET: PatientAppt/Add
        public IActionResult Add(int PaperInfoID)
        {
            //if (!PaperInfoID.HasValue)
            //{
            //    return RedirectToAction("Index", "PaperInfos");
            //}
            

            ReviewAssign a = new ReviewAssign()
            {
                PaperInfoID = PaperInfoID
            };


            //var paper = _context.PaperInfos
            //    .Include(p => p.PaperTitle)
            //    .Include(p => p.PaperType)
            //    .Include(p => p.ID)
            //    .Where(p => p.ID == PaperInfoID);
            //ViewBag.Paper = paper;
           

            //PopulateDropDownLists();



            return View(a);
        }

        //// POST: ReviewAssign/Add
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("ID,ReseacherID,RoleID,PaperInfoID")] ReviewAssign reviewAssign, string PaperTitle, int? PaperInfoID)
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
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            

            //PopulateDropDownLists(reviewAssign);
            ViewData["PaperTitle"] = PaperTitle;
            return View(reviewAssign);
        }

        //// GET: PatientAppt/Edit/5
        //public async Task<IActionResult> Update(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var review = await _context.ReviewAssigns
        //        .Include(a => a.Recommend)
        //        .Include(a => a.ReviewAgain)
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (review == null)
        //    {
        //        return NotFound();
        //    }
        //    PopulateDropDownLists(review);
        //    return View(review);
        //}

        //// POST: PatientAppt/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Update(int id)
        //{
        //    var reviewToUpdate = await _context.ReviewAssigns
        //        .Include(a => a.Recommend)
        //        .Include(a => a.ReviewAgain)
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    //Check that you got it or exit with a not found error
        //    if (reviewToUpdate == null)
        //    {
        //        return NotFound();
        //    }

        //    //Try updating it with the values posted
        //    if (await TryUpdateModelAsync<ReviewAssign>(reviewToUpdate, ""
        //        /*p => p.Notes, p => p.appDate, p => p.extraFee, p => p.ApptReasonID*/))
        //    {
        //        try
        //        {
        //            _context.Update(reviewToUpdate);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction("Index", new { reviewToUpdate.PaperInfoID });
        //        }

        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ReviewExists(reviewToUpdate.ID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        catch (DbUpdateException)
        //        {
        //            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
        //        }
        //    }
        //    PopulateDropDownLists(reviewToUpdate);
        //    return View(reviewToUpdate);
        //}

        //// GET: PatientAppt/Delete/5
        //public async Task<IActionResult> Remove(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var review = await _context.ReviewAssigns
        //        .Include(a => a.ReviewAgain)
        //        .Include(a => a.Recommend)
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (review == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(review);
        //}

        //// POST: PatientAppt/Delete/5
        //[HttpPost, ActionName("Remove")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> RemoveConfirmed(int id)
        //{
        //    var review = await _context.ReviewAssigns
        //        .Include(a => a.Recommend)
        //        .Include(a => a.ReviewAgain)
        //        .FirstOrDefaultAsync(m => m.ID == id);

        //    try
        //    {
        //        _context.ReviewAssigns.Remove(review);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index", new { review.PaperInfoID });
        //    }
        //    catch (Exception)
        //    {
        //        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
        //    }

        //    return View(review);
        //}

        private SelectList ReviewAssign(int? id)
        {
            var dQuery = from d in _context.Researchers
                         orderby d.FullName
                         select d;
            return new SelectList(dQuery, "ID", "Researcher", id);
        }

        private void PopulateDropDownLists(ReviewAssign reviewAssign = null)
       {
           ViewData["ID"] = ReviewAssign(reviewAssign?.ID);
       }

        private bool ReviewExists(int id)
        {
            return _context.ReviewAssigns.Any(e => e.ID == id);
        }

    }
}