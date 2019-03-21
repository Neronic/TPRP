using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRPR.Models
{
    public class ReviewAssign
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

        [Display(Name = "A discussion of implications for TR practice which describes the contribution the study makes to therapeutic recreation practice and provides specific recommendations for practice ")]
        public string RevContentReview { get; set; }

        [Display(Name = "Do the 5-6 keywords best describe content of the article? ")]
        public string RevKeywordReview { get; set; }

        [Display(Name = "Is the length of the manuscript a maximum number of 15 pages including references?")]
        public string RevLengthReview { get; set; }

        [Display(Name = "Is it formatted properly?")]
        public string RevFormatReview { get; set; }

        [Display(Name = "Do the citations and referencing follow the guidelines?")]
        public string RevCitationReview { get; set; }

        [Display(Name = "*Recommendation")]
        public int RecommendID { get; set; }
        public Recommend Recommend { get; set; }

        [Display(Name = "*Would you be willing to review a revision of this paper?")]
        public int ReviewAgainID { get; set; }
        public ReviewAgain ReviewAgain { get; set; }

        [Display(Name = "Files")]
        public ICollection<File> Files { get; set; }

    }
}
