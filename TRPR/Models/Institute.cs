using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRPR.Models
{
    public class Institute
    {
        public int ID { get; set; }

        [Display(Name = "Institute Name")]
        [Required(ErrorMessage = "You cannot leave the name of the institute blank.")]
        [StringLength(100, ErrorMessage = "Name must be under 100 characters")]
        public string InstName { get; set; }

        public ICollection<ResearchInstitute> ResearchInstitutes { get; set; }
    }
}
