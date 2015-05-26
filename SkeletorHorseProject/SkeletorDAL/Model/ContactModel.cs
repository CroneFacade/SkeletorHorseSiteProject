using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SkeletorDAL.Model
{
   public class ContactModel
    {
        [Required(ErrorMessage = "Can not be empty")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Can not be empty")]
        [EmailAddress(ErrorMessage = "Invalid adress")]
        public string EmailAdress { get; set; }

        [Required(ErrorMessage = "Can not be empty")]
        [MaxLength(1000)]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
        public HttpPostedFileBase Upload { get; set; }
        
        [Required(ErrorMessage = "Invalid Captcha")]
        public string ValidationNumber { get; set; }
    }
}
