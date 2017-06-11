using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace JobPortalDAL.Entity
{
    public class User
    {
        public int ID { get; set; }

        public String Role { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }        
        public HttpPostedFileBase file { get; set; }
        public String ProfileImgPath { get; set; }

        public DateTime? RegistrationDate { get; set; }
        public Boolean SMSActive { get; set; }
        public Boolean EmailActive { get; set; }
        public Boolean AccountActive { get; set; }

        public DateTime? LastLogin { get; set; }
        public DateTime? LastJobAppliedDate { get; set; }
    }
}
