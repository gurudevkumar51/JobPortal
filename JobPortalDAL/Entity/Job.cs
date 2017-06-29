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
       
        public Nullable<int> UserID { get; set; }

        public Nullable<int> JobTypeID { get; set; }

        public Nullable<System.DateTime> CreatedDate { get; set; }

        public string JobDescription { get; set; }

        public string JobLocation { get; set; }

        public Nullable<decimal> MinExperienceRequired { get; set; }

        public Nullable<decimal> MaxExperienceRequired { get; set; }

        public Nullable<System.DateTime> ExpireDate { get; set; }

        public Nullable<bool> IsActive { get; set; }

    }
}
