using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalDAL.Entity
{
    public class ExperienceDetails
    {
        public int UserID { get; set; }
        public String UserName { get; set; }
        public string JobTitle { get; set; }
        public string EmployerName { get; set; }
        public string Description { get; set; }
        public DateTime? joinDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Boolean IsCurrentJob { get; set; }
    }
}
