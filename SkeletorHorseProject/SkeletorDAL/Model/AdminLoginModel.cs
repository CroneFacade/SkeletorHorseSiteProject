using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkeletorHorseProject.Models
{
    public class AdminLoginModel
    {
        [Required, MinLength(1), MaxLength(12)]
        public string Username { get; set; }
        [Required, MinLength(1), MaxLength(20)]
        public string Password { get; set; }
    }
}