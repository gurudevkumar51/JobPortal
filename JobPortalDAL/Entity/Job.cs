using JobPortalDAL.Entity.MasterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalDAL.Entity
{
    public class Job
    {
        public int ID { get; set; }
        public int EmployerID { get; set; }
        public string EmployerName { get; set; }

        public int JobTypeID { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string JobDescription { get; set; }
        public string JobLocation { get; set; }
        public Decimal? MinExperienceReq { get; set; }
        public Decimal? MaxExperienceReq { get; set; }
        public DateTime? ExpireDate { get; set; }

        public List<Skill> SkillRequired { get; set; }

        public Boolean IsActive { get; set; }

    }
}
