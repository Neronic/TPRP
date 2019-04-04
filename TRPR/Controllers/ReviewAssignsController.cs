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
    public class ReviewAssignsController : Controller
    {
        private readonly TRPRContext _context;

        public ReviewAssignsController(TRPRContext context)
        {
            _context = context;
        }

        // GET: ReviewAssigns
        public async Task<IActionResult> Index(string SearchRes, string SearchTitle, int? CreatedOn, int? page, string sortDirection, string actionButton, string sortField = "CreatedOn")
        {
            var reviewAssigns = from r in _context.ReviewAssigns
                .Include(ra => ra.Roles)
                .Include(ra => ra.Researcher)
                .ThenInclude(r => r.ResearchExpertises)
                .ThenInclude(re => re.Expertise)
                .Include(r => r.PaperInfo)
                .Where(c => c.Researcher.ResEmail == User.Identity.Name)
                select r;           


            if (User.IsInRole("Editor"))
            {
                reviewAssigns = from r in _context.ReviewAssigns
               .Include(ra => ra.Roles)
               .Include(ra => ra.Researcher)
               .ThenInclude(r => r.ResearchExpertises)
               .ThenInclude(re => re.Expertise)
               .Include(r => r.PaperInfo)              
               select r;
            }

            if (!String.IsNullOrEmpty(SearchRes))
            {
                reviewAssigns = reviewAssigns.Where(p => p.Researcher.ResFirst.ToUpper().Contains(SearchRes.ToUpper()) || p.Researcher.ResLast.ToUpper().Contains(SearchRes.ToUpper()));
                ViewData["Filtering"] = " in";
            }
            if (!String.IsNullOrEmpty(SearchTitle))
            {
                reviewAssigns = reviewAssigns.Where(p => p.PaperInfo.PaperTitle.ToUpper().Contains(SearchTitle.ToUpper()));
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
            if (sortField == "Paper Title")//Sorting by Status
            {
                if (String.IsNullOrEmpty(sortDirection))
                {
                    reviewAssigns = reviewAssigns
                        .OrderBy(p => p.PaperInfo.PaperTitle);
                }
                else
                {
                    reviewAssigns = reviewAssigns
                       .OrderByDescending(p => p.PaperInfo.PaperTitle);
                }
            }
            else if (sortField == "Researcher")//Sorting by Status
            {
                if (String.IsNullOrEmpty(sortDirection))
                {
                    reviewAssigns = reviewAssigns
                        .OrderBy(p => p.Researcher.FullName);
                }
                else
                {
                    reviewAssigns = reviewAssigns
                       .OrderByDescending(p => p.Researcher.FullName);
                }
            }
            else
            {
                if (String.IsNullOrEmpty(sortDirection))
                {
                    reviewAssigns = reviewAssigns
                        .OrderByDescending(p => p.CreatedOn);
                }
                else
                {
                    reviewAssigns = reviewAssigns
                       .OrderBy(p => p.CreatedOn);
                }
            }

            //Set sort for next time
            ViewData["sortField"] = sortField;
            ViewData["sortDirection"] = sortDirection;

            int pageSize = 20;//Change as required
            var pagedData = await PaginatedList<ReviewAssign>.CreateAsync(reviewAssigns.AsNoTracking(), page ?? 1, pageSize);

            return View(pagedData);
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
        public async Task<IActionResult> Create([Bind("PaperInfoID,ResearcherID,RoleID,RevContentReview,RevKeywordReview,RevLengthReview,RevFormatReview,RevCitationReview,RecommendID,ReviewAgainID")] ReviewAssign reviewAssign)
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
            catch (Exception)
            {
                 ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            PopulateDropDownLists();
            PopulateExpertiseDropDownList();


            // Email coding
            //var researcher = await _context.Researchers
            //        .SingleOrDefaultAsync(m => m.ID == reviewAssign.ResearcherID);

            //var resEmail = researcher.ResEmail.ToString();
            //var resName = researcher.FullName.ToString();


            //var message = new MimeMessage();
            //message.From.Add(new MailboxAddress("TRPR", "TRPRDoNotReply@gmail.com"));
            //message.To.Add(new MailboxAddress(resName, "davilee.maitre@gmail.com"));
            //message.Subject = "TRPR - New Review";

            //message.Body = new TextPart("plain")
            //{
            //    Text = @"You've been assigned to a new review, head to TRPR to check it out!"
            //};

            //using (var client = new SmtpClient())
            //{
            //    // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
            //    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

            //    client.Connect("smtp-relay.gmail.com", 587, false);

            //    // Note: only needed if the SMTP server requires authentication
            //    client.Authenticate("TRPRDoNotReply@gmail.com", "Tq8uwocBDC");

            //    client.Send(message);
            //    client.Disconnect(true);
            //}


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
                { ////////////////////////////////////////////////////////////// STILL NEED WHERE LOGIC
                  //var paperID = _context.ReviewAssigns.Include(r => r.PaperInfo);
                    var reviewList = from r in _context.ReviewAssigns
                       .Include(r => r.PaperInfo)
                       .Where(c => c.PaperInfoID == reviewToUpdate.PaperInfoID)
                                        select r;
                    foreach (var PaperInfoID in reviewList) {
                    var count = 0;
                        while (reviewToUpdate.RecommendID != null && count < 2)
                        {
                            count++;
                        }
                        if (count == 2)
                        {
                            reviewToUpdate.PaperInfo.StatusID = 1;
                        }
                   }
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
