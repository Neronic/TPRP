using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TRPR.Data;
using TRPR.Models;

namespace TRPR.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {

        private readonly TRPRContext _context;

        public HomeController(TRPRContext context) {
            _context = context;
        }


        public IActionResult Index()
        {
            if (User.IsInRole("Editor"))
            {
                return View("IndexEditor");
            }
            else if (User.IsInRole("Researcher"))
            {
                var papers = from p in _context.PaperInfos
                     .Include(p => p.Status )
                     .Include(p => p.Files)
                     .Include(p => p.AuthoredPapers)
                     .ThenInclude(pc => pc.Researcher)
                     select p;

                return View("IndexResearcher");
            }
            else
            {
                return View();
            }

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
