using System;
using MyApp.Data.Models;
namespace MyApp.ViewModels
{
	public class CreditCartViewModel
	{
		public string warning { get; set; }
		public AuthModel user { get; set; }
        public CreditCart creditCart { get; set; }
		public ApplyCredit applyCredit { get; set; }
        public CreditCartViewModel()
		{
			
		}
	}
}

