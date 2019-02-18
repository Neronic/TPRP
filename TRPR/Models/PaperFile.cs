using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRPR.Models
{
    public class PaperFile
    {
        public int PaperID { get; set; }
        public PaperInfo PaperInfo { get; set; }

        public int FileID { get; set; }
        public File File { get; set; }
    }
}
