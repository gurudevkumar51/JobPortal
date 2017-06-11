using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalDAL.Entity
{
    class EducationDetails
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public String CertificationName { get; set; }
        public string Stream { get; set; }
        public string InstituteName { get; set; }
        public string UniversityName { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public Decimal? Percentage { get; set; }
        public Decimal? CGPA { get; set; }
    }
}
