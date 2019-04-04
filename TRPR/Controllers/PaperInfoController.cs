using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
    public class PaperInfoController : Controller
    {
        private readonly TRPRContext _context;

        public PaperInfoController(TRPRContext context)
        {
            _context = context;
        }

        // GET: PaperInfo
        public async Task<IActionResult> Index(string SearchString, int? CreatedOn, int? PaperTypeID, int? StatusID, int? KeywordID, int? page, string sortDirection, string actionButton, string sortField = "CreatedOn")
        {
            var papers = from p in _context.PaperInfos
                .Include(p => p.Status)
                .Include(p => p.Files)
                .Include(p => p.AuthoredPapers)
                .ThenInclude(pc => pc.Researcher)
                         select p;

            //if (User.IsInRole("Researcher"))
            //{
            //    papers = from p in _context.PaperInfos
            //    .Include(p => p.Status)
            //    .Include(p => p.Files)
            //    .Include(p => p.AuthoredPapers)
            //    .ThenInclude(pc => pc.Researcher)
            //    .Where(c => c.CreatedBy == User.Identity.Name)
            //             select p;
            //}

            if (User.IsInRole("Editor"))
            {
                papers = from p in _context.PaperInfos
                .Include(p => p.Status)
                .Include(p => p.Files)
                .Include(p => p.ReviewAssigns)
                .ThenInclude(pc => pc.Researcher)
                .ThenInclude(pc => pc.ResEmail)
                //.Where(pc.ResEmail == User.Identity.Name)
                         select p;
            }

            else if (User.IsInRole("Editor"))
            {
                papers = from p in _context.PaperInfos
                .Include(p => p.Status)
                .Include(p => p.Files)
                .Include(p => p.AuthoredPapers)
                .ThenInclude(pc => pc.Researcher)
                
                         select p;
            }
            else

            {
                papers = from p in _context.PaperInfos
                .Include(p => p.Status)
                .Include(p => p.Files)
                .Include(p => p.AuthoredPapers)
                .ThenInclude(pc => pc.Researcher)
                .Include(p => p.PaperKeywords)
                .ThenInclude(pk => pk.Keyword)                
                         select p;
            } 
            

            PopulateDropDownLists();
            ViewData["KeywordID"] = new SelectList(_context.Keywords.OrderBy(p => p.KeyWord), "ID", "KeyWord");
            ViewData["Filtering"] = "";

            //Add as many filters as needed
            if (PaperTypeID.HasValue)
            {
                papers = papers.Where(p => p.PaperTypeID == PaperTypeID);
                ViewData["PaperTypeIDFilter"] = PaperTypeID;
                ViewData["Filtering"] = " in";
            }
            if (StatusID.HasValue)
            {
                papers = papers.Where(p => p.StatusID == StatusID);
                ViewData["Filtering"] = " in";
            }
            if (KeywordID.HasValue)
            {
                papers = papers.Where(p => p.PaperKeywords.Any(c => c.KeywordID == KeywordID));
                ViewData["Filtering"] = " in";
            }

            if (!String.IsNullOrEmpty(SearchString))
            {
                papers = papers.Where(p => p.PaperTitle.ToUpper().Contains(SearchString.ToUpper()));
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
            if (sortField == "Status")//Sorting by Status
            {
                if (String.IsNullOrEmpty(sortDirection))
                {
                    papers = papers
                        .OrderBy(p => p.Status.StatName);
                }
                else
                {
                    papers = papers
                       .OrderByDescending(p => p.Status.StatName);
                }
            }
            else if (sortField == "Paper Type")
            {
                if (String.IsNullOrEmpty(sortDirection))
                {
                    papers = papers
                        .OrderBy(p => p.PaperType.Name);
                }
                else
                {
                    papers = papers
                        .OrderByDescending(p => p.PaperType.Name);
                }
            }
            else if (sortField == "Length")
            {
                if (String.IsNullOrEmpty(sortDirection))
                {
                    papers = papers
                        .OrderBy(p => p.PaperLength);
                }
                else
                {
                    papers = papers
                        .OrderByDescending(p => p.PaperLength);
                }
            }
            else if (sortField == "Title")//Sorting by Title - the default sort order
            {
                if (String.IsNullOrEmpty(sortDirection))
                {
                    papers = papers
                        .OrderBy(p => p.PaperTitle);
                }
                else
                {
                    papers = papers
                       .OrderByDescending(p => p.PaperTitle);
                }
            }
            else
            {
                if (String.IsNullOrEmpty(sortDirection))
                {
                    papers = papers
                        .OrderByDescending(p => p.CreatedOn);
                }
                else
                {
                    papers = papers
                       .OrderBy(p => p.CreatedOn);
                }
            }
            //Set sort for next time
            ViewData["sortField"] = sortField;
            ViewData["sortDirection"] = sortDirection;

            int pageSize = 10;//Change as required
            var pagedData = await PaginatedList<PaperInfo>.CreateAsync(papers.AsNoTracking(), page ?? 1, pageSize);


            return View(pagedData);

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

            var viewerFiles = _context.Files
                .Where(f => f.PaperInfoID == id);// && (f.FileContent.MimeType.Contains("pdf")) || (f.FileContent.MimeType.Contains("image")));
            ViewData["ViewerFileID"] = new SelectList(viewerFiles, "ID", "FileName");

            return View(paperInfo);

            /*var theFile = _context.Files.Where(f => f.ID == id).SingleOrDefault();
            
            string fileBase64 = Convert.ToBase64String(theFile.FileContent);
            string MimeType = theFile?.FileMimeType;
            string downLink = "<a href='/patients/download/" + theFile.ID + "' title='Download: " + theFile.FileType + "'>" + theFile.FileName + "</a>";
                       
            ViewData["MimeType"] = MimeType;
            ViewData["fileBase64"] = fileBase64;
            ViewData["downloadLink"] = downLink;

            return View(theFile);*/


        }

        public PartialViewResult GetViewerPartial(int? id)
        {
            string fileBase64 = "";//For our Byte[] converted to Base64 String
            string downLink = "";//In case the file cannot be displayed
            string MimeType = "";//So the partial view can decide what to do with the file

            var theFile = _context.Files.Where(f => f.ID == id).SingleOrDefault();
            if (theFile != null)
            {
                fileBase64 = Convert.ToBase64String(theFile.FileContent);
                MimeType = theFile?.FileMimeType;
                downLink = "<a href='/patients/download/" + theFile.ID + "' title='Download: " + theFile.FileType + "'>" + theFile.FileName + "</a>";
            }
            ViewData["MimeType"] = MimeType;
            ViewData["fileBase64"] = fileBase64;
            ViewData["downloadLink"] = downLink;
            return PartialView("_pdfViewer");
        }

        // GET: PaperInfo/Create
        public IActionResult Create()
        {
<<<<<<< HEAD
            var paperInfo = new PaperInfo();
            PopulateAssignedKeywordData(paperInfo);
=======

>>>>>>> victoriaNew
            PopulateDropDownLists();
            return View();
        }


        // POST: PaperInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PaperTitle,PaperAbstract,PaperTypeID,PaperLength,StatusID")] PaperInfo paperInfo, IEnumerable<IFormFile> theFiles, string[] selectedOptions)
        {
            try
            {
                UpdatePaperKeywords(selectedOptions, paperInfo);
                if (ModelState.IsValid)
                {
                    await AddDocuments(paperInfo, theFiles);
                    paperInfo.StatusID = 3;
                    _context.Add(paperInfo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes after multiple attempts. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateDropDownLists(paperInfo);
            PopulateAssignedKeywordData(paperInfo);
            return View(paperInfo);
        }

        private async Task AddDocuments(PaperInfo paperInfo, IEnumerable<IFormFile> theFiles)
        {
            foreach (var f in theFiles)
            {
                if (f != null)
                {
                    string mimeType = f.ContentType;
                    long fileLength = f.Length;
                    if (!(mimeType == "" || fileLength == 0))//Looks like we have a file!!!
                    {
                        using (var memoryStream = new System.IO.MemoryStream())
                        {
                            await f.CopyToAsync(memoryStream);
                            File newFile = new File
                            {

                                FileContent = memoryStream.ToArray(),
                                FileMimeType = mimeType,
                                FileName = f.FileName


                            };
                            paperInfo.Files.Add(newFile);
                        }
                    };
                }
            }
        }

        // GET: PaperInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paperInfo = await _context.PaperInfos
                .Include(p => p.Status)
                .Include(p => p.Files)
                .Include(p => p.AuthoredPapers)
                .ThenInclude(pc => pc.Researcher)
                .Include(p => p.PaperKeywords)
                .ThenInclude(pk => pk.Keyword)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (paperInfo == null)
            {
                return NotFound();
            }
            PopulateDropDownLists();
            PopulateAssignedKeywordData(paperInfo);
            return View(paperInfo);
        }

        // POST: PaperInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string[] selectedOptions)
        {
            var paperToUpdate = await _context.PaperInfos
               .Include(p => p.Status)
               .Include(p => p.Files)
               .Include(p => p.AuthoredPapers)
               .ThenInclude(pc => pc.Researcher)
               .Include(p => p.PaperKeywords)
               .ThenInclude(pk => pk.Keyword)
               .SingleOrDefaultAsync(m => m.ID == id);

            if (id != paperToUpdate.ID)
            {
                return NotFound();
            }

            UpdatePaperKeywords(selectedOptions, paperToUpdate);

            if (await TryUpdateModelAsync<PaperInfo>(paperToUpdate, "",
                            r => r.PaperTitle, r => r.PaperAbstract, r => r.PaperTypeID, r => r.PaperLength, r => r.StatusID))
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
                    if (!PaperInfoExists(paperToUpdate.ID))
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
            PopulateAssignedKeywordData(paperToUpdate);
            return View(paperToUpdate);
        }

        // GET: PaperInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paperInfo = await _context.PaperInfos
                .Include(p => p.Status)
                .Include(p => p.Files)
                .Include(p => p.AuthoredPapers)
                .ThenInclude(pc => pc.Researcher)
                .Include(p => p.PaperKeywords)
                .ThenInclude(pk => pk.Keyword)
                .AsNoTracking()
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

        public FileResult Download(int id)
        {
            var theFile = _context.Files.Where(f => f.ID == id).SingleOrDefault();
            return File(theFile.FileContent, theFile.FileMimeType, theFile.FileName);
        }

        private SelectList StatusSelectList(int? id)
        {
            var dQuery = from d in _context.Statuses
                         orderby d.StatName
                         select d;
            return new SelectList(dQuery, "ID", "StatName", id);
        }

        private SelectList PaperTypeSelectList(int? id)
        {
            var dQuery = from d in _context.PaperTypes
                         orderby d.Name
                         select d;
            return new SelectList(dQuery, "ID", "Name", id);
        }


        private void PopulateDropDownLists(PaperInfo infos = null)
        {
            ViewData["StatusID"] = StatusSelectList(infos?.StatusID);
            ViewData["PaperTypeID"] = PaperTypeSelectList(infos?.PaperTypeID);
        }

        [HttpGet]
        public JsonResult GetStatuses(int? id)
        {
            return Json(StatusSelectList(id));
        }

        private void PopulateAssignedKeywordData(PaperInfo paper)
        {
            var allKeywords = _context.Keywords;
            var papKeywords = new HashSet<int>(paper.PaperKeywords.Select(b => b.KeywordID));
            var selected = new List<KeywordVM>();
            var available = new List<KeywordVM>();
            foreach (var s in allKeywords)
            {
                if (papKeywords.Contains(s.ID))
                {
                    selected.Add(new KeywordVM
                    {
                        KeywordID = s.ID,
                        KeyWord = s.KeyWord
                    });
                }
                else
                {
                    available.Add(new KeywordVM
                    {
                        KeywordID = s.ID,
                        KeyWord = s.KeyWord
                    });
                }
            }

            ViewData["selOpts"] = new MultiSelectList(selected.OrderBy(s => s.KeyWord), "KeywordID", "KeyWord");
            ViewData["availOpts"] = new MultiSelectList(available.OrderBy(s => s.KeyWord), "KeywordID", "KeyWord");
        }

        private void UpdatePaperKeywords(string[] selectedOptions, PaperInfo paperToUpdate)
        {
            if (selectedOptions == null)
            {
                paperToUpdate.PaperKeywords = new List<PaperKeyword>();
                return;
            }

            var selectedOptionsHS = new HashSet<string>(selectedOptions);
            var papKeywords = new HashSet<int>(paperToUpdate.PaperKeywords.Select(b => b.KeywordID));
            foreach (var s in _context.Keywords)
            {
                if (selectedOptionsHS.Contains(s.ID.ToString()))
                {
                    if (!papKeywords.Contains(s.ID))
                    {
                        paperToUpdate.PaperKeywords.Add(new PaperKeyword
                        {
                            PaperInfoID = paperToUpdate.ID,
                            KeywordID = s.ID,
                        });
                    }
                }
                else
                {
                    if (papKeywords.Contains(s.ID))
                    {
                        PaperKeyword specToRemove = paperToUpdate.PaperKeywords.SingleOrDefault(d => d.KeywordID == s.ID);
                        _context.Remove(specToRemove);
                    }
                }
            }
        }
    }
}
