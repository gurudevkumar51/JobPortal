using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalDAL.Entity
{
    public class Login
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public Boolean RememberMe { get; set; }
    }
}
