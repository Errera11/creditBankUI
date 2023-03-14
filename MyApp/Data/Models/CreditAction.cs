using System;
using System.ComponentModel.DataAnnotations;
namespace MyApp.Data.Models
{
    public class CreditAction
    {
        [Display(Name = "Value to deposit")]
        public int depositValue { get; set; }

        [Display(Name = "Value to withdraw")]
        public int withdrawValue { get; set; }
    }
}

