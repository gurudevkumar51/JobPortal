using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using JobPortalDAL.Entity.MasterEntities;

namespace JobPortalDAL.Entity
{
    public class SeekerProfile
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Decimal? CurrentSalary { get; set; }
        public Decimal? ExpectedSalary { get; set; }
        public string Introduction { get; set; }
        public string SalaryCurrency { get; set; }

        public HttpPostedFileBase ResumeFile { get; set; }
        public string ResumePath { get; set; }

        public DateTime? DOB { get; set; }
        public string Gender { get; set; }

        public List<Skill> Skills { get; set; }

        public List<JobActivity> ActivitiesOnJob { get; set; }

        public List<SocialMediaProfiles> SocialProfiles { get; set; }

    }
}
