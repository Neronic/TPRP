using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRPR.Models
{
    public class Status
    {
        public int ID { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "You cannot leave the keyword blank.")]
        [StringLength(20, ErrorMessage = "Name must be under 20 characters")]
        public string StatName { get; set; }

        //public ICollection<PatientCondition> PatientConditions { get; set; }
    }
}
