using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRPR.Models
{
    public class Researcher
    {
        public Researcher()
        {
            this.ResearchExpertises = new HashSet<ResearchExpertise>();
            this.ResearchInstitutes = new HashSet<ResearchInstitute>();
            this.AuthoredPapers = new HashSet<AuthoredPaper>();
            this.ReviewAssigns = new HashSet<ReviewAssign>();
        }

        [Display(Name = "Researcher")]
        public string FullName
        {
            get
            {
                return  ResFirst
                    + (string.IsNullOrEmpty(ResMiddle) ? " " :
                        (" " + (char?)ResMiddle[0] + ". ").ToUpper())
                    + ResLast;
            }
        }

        public int ID { get; set; }

        [Display(Name = "Title")]
        [StringLength(10, ErrorMessage = "Title name cannot be more than 10 characters long.")]
        public string ResTitle { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You cannot leave the first name blank.")]
        [StringLength(50, ErrorMessage = "First name cannot be more than 50 characters long.")]
        public string ResFirst { get; set; }

        [Display(Name = "Middle Name")]
        [StringLength(50, ErrorMessage = "Middle name cannot be more than 50 characters long.")]
        public string ResMiddle { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You cannot leave the last name blank.")]
        [StringLength(50, ErrorMessage = "Last name cannot be more than 50 characters long.")]
        public string ResLast { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address is required.")]
        [StringLength(320)]
        [DataType(DataType.EmailAddress)]
        public string ResEmail { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "You cannot leave the biography blank.")]
        [StringLength(500, ErrorMessage = "Biography cannot be more than 500 characters long.")]
        public string ResBio { get; set; }

        [Display(Name = "Expertises")]
        public virtual ICollection<ResearchExpertise> ResearchExpertises { get; set; }

        [Display(Name = "Institute")]
        public virtual ICollection<ResearchInstitute> ResearchInstitutes { get; set; }

        [Display(Name = "Authored Papers")]
        public virtual ICollection<AuthoredPaper> AuthoredPapers { get; set; }

        [Display(Name = "Reviews")]
        public virtual ICollection<ReviewAssign> ReviewAssigns { get; set; }
    }
}
