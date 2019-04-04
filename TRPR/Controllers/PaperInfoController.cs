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
    public class PaperInfoController : Controller
    {
        private readonly TRPRContext _context;

        public PaperInfoController(TRPRContext context)
        {
            _context = context;
        }

        // GET: PaperInfo
        public async Task<IActionResult> Index(string SearchString, int? PaperTypeID, int? StatusID, int? KeywordID, int? page, string sortDirection, string actionButton, string sortField = "Title")
        {
            PopulateDropDownLists();
            ViewData["KeywordID"] = new SelectList(_context.Keywords.OrderBy(p => p.KeyWord), "ID", "KeyWord");
            ViewData["Filtering"] = "";           

            var papers = from p in _context.PaperInfos
                .Include(p => p.Status)
                .Include(p => p.Files)
                .Include(p => p.AuthoredPapers)
                .ThenInclude(pc => pc.Researcher)
                select p;

            int pageSize = 10;//Change as required
            var pagedData = await PaginatedList<PaperInfo>.CreateAsync(papers.AsNoTracking(), page ?? 1, pageSize);

            //Add as many filters as needed
            if (PaperTypeID.HasValue)
            {
                papers = papers.Where(p => p.PaperTypeID == PaperTypeID);
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
            if (sortField == "Status")//Sorting by Patient Name
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
            else //Sorting by Title - the default sort order
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
            //Set sort for next time
            ViewData["sortField"] = sortField;
            ViewData["sortDirection"] = sortDirection;

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
                downLink = "<a href='/paperinfo/download/" + theFile.ID + "' title='Download: " + theFile.FileType + "'>" + theFile.FileName + "</a>";
            }
            ViewData["MimeType"] = MimeType;
            ViewData["fileBase64"] = fileBase64;
            ViewData["downloadLink"] = downLink;
            return PartialView("_pdfViewer");
        }
        
        // GET: PaperInfo/Create
        public IActionResult Create()
        {
            
            PopulateDropDownLists();
            return View();
        }
        

        // POST: PaperInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PaperTitle,PaperAbstract,PaperTypeID,PaperLength,StatusID")] PaperInfo paperInfo, IEnumerable<IFormFile> theFiles)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await AddDocuments(paperInfo, theFiles);
                    paperInfo.StatusID = 2;
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
    }
}
