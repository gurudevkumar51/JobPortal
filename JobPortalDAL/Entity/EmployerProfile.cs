using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalDAL.Entity
{
    public class EmployerProfile
    {
        public int UserID { get; set; }
        public  string  Industry { get; set; }
        public string CompanyName { get; set; }
        public DateTime? EstablishDate { get; set; }
        public string WebURL { get; set; }

        public List<SocialMediaProfiles> SocialProfiles { get; set; }
    }
}
