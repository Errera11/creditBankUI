using System;
using System.ComponentModel.DataAnnotations;
namespace MyApp.Data.Models
{
	public class AuthModel
	{
		public string Login {get; set;}

		[DataType(DataType.Password)]
        public string Password { get; set; }

        public ClientCredit clientCredit { get; set; }
        public AuthModel()
		{
		}
	}
}

