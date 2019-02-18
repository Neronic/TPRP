using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRPR.Models
{
    public class ReviewFile
    {
        public int RevID { get; set; }
        public ReviewAssign ReviewAssign { get; set; }

        public int FileID { get; set; }
        public File File { get; set; }
    }
}
