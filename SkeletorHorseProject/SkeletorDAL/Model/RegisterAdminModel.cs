using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletorDAL.Model
{
    public class RegisterAdminModel
    {
        [Required]
        [StringLength(12, MinimumLength = 1, ErrorMessage = "Username must be 1-12 characters long")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Password must be 1-20 characters long")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm Password must match with Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Admin Level (1-5)")]
        [Range(1, 5, ErrorMessage = "Admin Level must be between 1-5")]
        public int AdminLevel { get; set; }

        public bool IsActive { get; set; }
    }
}
