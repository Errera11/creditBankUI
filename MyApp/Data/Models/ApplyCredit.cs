using System;
using System.ComponentModel.DataAnnotations;
namespace MyApp.Data.Models
{
	public class ApplyCredit
	{
        [Display(Name = "Enter login")]
        [Required(ErrorMessage = "Required")]
        public string login { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Enter password")]
        [Required(ErrorMessage = "Required")]
        public string password { get; set; }

        [Display(Name="Enter your name")]
        [Required(ErrorMessage = "wow")]
		public string name { get; set; }

        [Display(Name = "Enter your lastname")]
        public string lastname { get; set; }

        [Display(Name = "Enter your age")]
        public int age { get; set; }

        [Display(Name = "Enter your income")]
        public int income { get; set; }

        [Display(Name = "Enter your job")]
        public string job { get; set; }

        
    }
}

