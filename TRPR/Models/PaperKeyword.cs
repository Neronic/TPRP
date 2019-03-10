using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRPR.Models
{
    public class PaperKeyword
    {
        public int PaperInfoID { get; set; }
        public PaperInfo PaperInfo { get; set; }

        public int KeywordID { get; set; }
        public Keyword Keyword { get; set; }
    }
}
