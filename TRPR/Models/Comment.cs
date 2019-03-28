using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRPR.Models
{
    public class Comment : Auditable
    {
        public int ID { get; set; }

        [Display(Name = "Review")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select the review.")]
        public int RevID { get; set; }
        public ReviewAssign ReviewAssign { get; set; }

        [Display(Name = "Access")]
        [Required(ErrorMessage = "You must select who this comment is dirrected to.")]
        [StringLength(50, ErrorMessage = "First name cannot be more than 50 characters long.")]
        public string ComAccess { get; set; }

        [Display(Name = "Content")]
        [Required(ErrorMessage = "You cannot leave the comment blank.")]
        [StringLength(500, ErrorMessage = "Comment cannot be more than 500 characters long.")]
        public string Comtext { get; set; }
    }
}
