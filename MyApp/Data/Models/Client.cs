using System;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Data.Models
{
	public class Client
	{
        public string Login { get; set; }

        
        public string Password { get; set; }

        public ClientCredit clientCredit { get; set; }
    }
}

