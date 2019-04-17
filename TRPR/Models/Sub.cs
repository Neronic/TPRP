using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TRPR.Models
{
    public class Sub
    {
        public int Id { get; set; }

        [StringLength(127)]
        public string Name { get; set; }

        [StringLength(512)]
        public string PushEndpoint { get; set; }

        [StringLength(512)]
        public string PushP256DH { get; set; }

        [StringLength(512)]
        public string PushAuth { get; set; }

        public int? ResearcherID { get; set; }
        public Researcher Researcher { get; set; }

    }
}
