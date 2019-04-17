using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRPR.Models
{
    public class ReviewAssign : Auditable
    {
        public ReviewAssign()
        {
            Files = new HashSet<File>();
        }

        public int ID { get; set; }

        [Display(Name = "Main Paper")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select the main paper.")]
        public int PaperInfoID { get; set; }
        public PaperInfo PaperInfo { get; set; }

        [Display(Name = "Reveiwer")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select the Reviewer.")]
        public int ResearcherID { get; set; }
        public Researcher Researcher { get; set; }

        [Display(Name = "Role")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select the role oif the reviewer.")]
        public int RoleID { get; set; }
        public Role Roles { get; set; }

        [Display(Name = "Content Review")]
        public string RevContentReview { get; set; }

        [Display(Name = "Keyword Review")]
        public string RevKeywordReview { get; set; }

        [Display(Name = "Length Review")]
        public string RevLengthReview { get; set; }

        [Display(Name = "Format Review")]
        public string RevFormatReview { get; set; }

        [Display(Name = "Citation Review")]
        public string RevCitationReview { get; set; }

        [Display(Name = "Comment to EiC")]
        public string EiCComment { get; set; }

        [Display(Name = "Comment to Author")]
        public string AuthorComment { get; set; }

        [Display(Name = "Recommendation")]
        public int? RecommendID { get; set; }
        public Recommend Recommend { get; set; }


        [Display(Name = "Review Again")]
        public int? ReviewAgainID { get; set; }
        public ReviewAgain ReviewAgain { get; set; }

        [Display(Name = "Files")]
        public ICollection<File> Files { get; set; }

        //[Display(Name = "Comment")]
        //public string Comment1 { get; set; }

        //[Display(Name = "Comment")]
        //public string Comment2 { get; set; }

    }
}
