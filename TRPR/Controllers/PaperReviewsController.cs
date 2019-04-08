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
    public class PaperReviewsController: Controller
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
                return RedirectToAction("Index", "Patients");
            }
            ViewData["PaperTitle"] = PaperTitle;

            ReviewAssign a = new ReviewAssign()
            {
                PaperInfoID = PaperInfoID.GetValueOrDefault()
            };

            //PopulateDropDownLists();
            return View(a);
        }

        //POST: Reviews/Add
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Add([Bind("ID, )])
    }
}