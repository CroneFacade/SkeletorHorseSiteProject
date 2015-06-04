using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletorDAL.Model
{
    public class EditAdminModel
    {
        public int ID { get; set; }

        [EmailAddress(ErrorMessage = "Invalid address, try again (example@teamnordahl.se)")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Password must be 1-20 characters long")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm Password must match with Password")]
        public string ConfirmPassword { get; set; }
    }
}
