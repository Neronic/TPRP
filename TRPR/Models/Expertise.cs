using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRPR.Models
{
    public class Expertise
    {
        public int ID { get; set; }

        [Display(Name = "Expertise Name")]
        [Required(ErrorMessage = "You cannot leave the name of the expertise blank.")]
        [StringLength(30, ErrorMessage = "Name must be under 30 characters")]
        public string ExpName { get; set; }

        public ICollection<ResearchExpertise> ResearchExpertises { get; set; }
    }
}
