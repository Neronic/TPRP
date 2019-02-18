using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRPR.Models
{
    public class Recommend
    {
        public int ID { get; set; }

        [Display(Name = "Recommendation")]
        [Required(ErrorMessage = "You cannot leave the name of the role blank.")]
        [StringLength(20, ErrorMessage = "Name must be under 20 characters")]
        public string RecTitle { get; set; }
    }
}
