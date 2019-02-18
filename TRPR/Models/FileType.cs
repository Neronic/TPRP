using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRPR.Models
{
    public class FileType
    {
        public int ID { get; set; }

        [Display(Name = "Expertise Name")]
        [Required(ErrorMessage = "You cannot leave the name of the type blank.")]
        [StringLength(50, ErrorMessage = "Name must be under 50 characters")]
        public string TypeName { get; set; }
    }
}
