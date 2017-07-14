using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalDAL.Entity
{
    public class APIUserResponse
    {
        public Boolean success { get; set; }
        public User[] responseText { get; set; }
        public string responseCode { get; set; }
    }
    public class APIJobResponse
    {
        public Boolean success { get; set; }
        public Job[] responseText { get; set; }
        public string responseCode { get; set; }
    }

}
