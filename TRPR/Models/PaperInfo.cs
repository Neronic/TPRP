using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRPR.Models
{
    public class PaperInfo
    {
        public PaperInfo()
        {
            PaperKeywords = new HashSet<PaperKeyword>();
            Files = new HashSet<File>();
        }

        public int ID { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "You cannot leave the title blank.")]
        [StringLength(200, ErrorMessage = "Title cannot be more than 200 characters long.")]
        public string PaperTitle { get; set; }

        [Display(Name = "Abstract")]
        [Required(ErrorMessage = "You cannot leave the abstract blank.")]
        [StringLength(500, ErrorMessage = "Abstract cannot be more than 500 characters long.")]
        public string PaperAbstract { get; set; }

        [Display(Name = "Type")]
        [Required(ErrorMessage = "You cannot leave the type blank.")]
        [StringLength(30, ErrorMessage = "Type cannot be more than 30 characters long.")]
        public string PaperType { get; set; }

        [Display(Name = "Length")]
        [Required(ErrorMessage = "You cannot leave the length blank.")]
        public int PaperLength { get; set; }

        [Display(Name = "Status")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select the status of the Paper.")]
        public int StatID { get; set; }
        public Status Status { get; set; }

        

        [Display(Name = "Keywords")]
        public ICollection<PaperKeyword> PaperKeywords { get; set; }

        [Display(Name = "Files")]
        public ICollection<File> Files { get; set; }

        [Display(Name = "Authored Papers")]
        public ICollection<AuthoredPaper> AuthoredPapers { get; set; }
    }
}
