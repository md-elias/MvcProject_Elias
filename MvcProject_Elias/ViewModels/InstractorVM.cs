using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcProject_Elias.ViewModels
{
    public class InstractorVM
    {
        public int InstractorID { get; set; }
        [Required]
        public string InstractorName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Cell Phone No.")]
        public string CellPhone { get; set; }

        [Required]
        [Display(Name = "Contact Address")]
        public string ContactAddress { get; set; }
    }
}