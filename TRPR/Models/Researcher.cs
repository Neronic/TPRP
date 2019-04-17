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
            this.AuthoredPapers = new HashSet<AuthoredPaper>();
            this.ReviewAssigns = new HashSet<ReviewAssign>();
            Subs = new HashSet<Sub>();
            Active = true;
        }


        [Display(Name = "Researcher")]
        public string FullName
        {
            get
            {
                return  ResFirst + " " + ResLast;
            }
        }

        public string FormalName
        {
            get
            {
                return Title + ". " + ResLast + ((char?)ResFirst[0] + ". ").ToUpper()
                    + (string.IsNullOrEmpty(ResMiddle) ? " " :
                        (" " + (char?)ResMiddle[0] + " ").ToUpper());
            }
        }

        public int ID { get; set; }

        [Display(Name = "Title")]
        //[Range(1, int.MaxValue, ErrorMessage = "You must select a title.")]
        public int TitleID { get; set; }
        public Title Title { get; set; }

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

        [Display(Name = "Professional Biography")]
        [Required(ErrorMessage = "You cannot leave the biography blank.")]
        [StringLength(500, ErrorMessage = "Biography cannot be more than 500 characters long.")]
        public string ResBio { get; set; }

        [Display(Name = "Areas of Expertises")]
        public virtual ICollection<ResearchExpertise> ResearchExpertises { get; set; }

        [Display(Name = "Affilitation")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select an Institute.")]
        public int InstituteID { get; set; }
        public Institute Institutes { get; set; }

        [Display(Name = "Authored Papers")]
        public virtual ICollection<AuthoredPaper> AuthoredPapers { get; set; }

        [Display(Name = "Reviews")]
        public virtual ICollection<ReviewAssign> ReviewAssigns { get; set; }

        public ICollection<Sub> Subs { get; set; }

        public bool Active { get; set; }
    }
}
