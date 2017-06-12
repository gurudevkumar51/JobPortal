using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalDAL.Entity
{
    public class Login
    {
        public string EmailId { get; set; }
        public string Password { get; set; }
        public Boolean RememberMe { get; set; }
    }
}
