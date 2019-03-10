using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRPR.Models
{
    public class ResearchExpertise
    {
        public int ExpertiseID { get; set; }
        public Expertise Expertise { get; set; }

        public int ResearcherID { get; set; }
        public Researcher Researcher { get; set; }
    }
}
