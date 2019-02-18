using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRPR.Models
{
    public class AuthoredPaper
    {
        public int ResID { get; set; }
        public Researcher Researcher { get; set; }

        public int PaperID { get; set; }
        public PaperInfo PaperInfo { get; set; }

        public string AuthPapLevel { get; set; }

    }
}
