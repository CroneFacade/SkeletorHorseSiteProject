using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletorDAL.Model
{
    class EditAdminModel
    {

        [StringLength(12, MinimumLength = 1, ErrorMessage = "Username must be 1-12 characters long")]
        [Display(Name = "Username")]
        public string Username { get; set; }

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

        [Display(Name = "Admin Level (1-5)")]
        [Range(1, 5, ErrorMessage = "Admin Level must be between 1-5")]
        public int AdminLevel { get; set; }

        [DisplayName("Delete admin")]
        public bool IsActive { get; set; }
    }
}
