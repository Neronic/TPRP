using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRPR.Models
{
    public class Keyword
    {
        public int ID { get; set; }

        [Display(Name = "Keyword")]
        [Required(ErrorMessage = "You cannot leave the keyword blank.")]
        [StringLength(100, ErrorMessage = "Name must be under 100 characters")]
        public string KeyWord { get; set; }

        public ICollection<PaperKeyword> PaperKeywords { get; set; }
    }
}
