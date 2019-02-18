using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRPR.Models
{
    public class File
    {
        public int ID { get; set; }

        [Display(Name = "File Name")]
        [Required(ErrorMessage = "You cannot leave the filenot be more than 100 characters long.")]
        public string FileName { get; set; }

        [Display(Name = "File Type")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select the type of file.")]
        public int TypeID { get; set; }
        public FileType FileType { get; set; }

        [ScaffoldColumn(false)]
        public byte[] FileContent { get; set; }

        [StringLength(256)]
        [ScaffoldColumn(false)]
        public string FileMimeType { get; set; }

        [ScaffoldColumn(false)]
        [StringLength(256)]
        public string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? CreatedOn { get; set; }

        [ScaffoldColumn(false)]
        [StringLength(256)]
        public string UpdatedBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? UpdatedOn { get; set; }
    }
}
