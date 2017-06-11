using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalDAL.Entity
{
    public class JobActivity
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public int UserID { get; set; }        
        public string Activity { get; set; }
        public DateTime? ActivityDate { get; set; }
    }
}
