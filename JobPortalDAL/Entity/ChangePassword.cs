using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalDAL.Entity
{
    public class ChangePassword
    {
        [Display(Name = "Old Password")]
        [DataType(DataType.Password)]
        [MaxLength(15, ErrorMessage = "Maximum 15 characters required")]
        public string Password { get; set; }

        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        [MaxLength(15, ErrorMessage = "Maximum 15 characters required")]
        public string NewPassword { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [MaxLength(15, ErrorMessage = "Maximum 15 characters required")]
        public string ConfirmNewPassword { get; set; }
    }
}
