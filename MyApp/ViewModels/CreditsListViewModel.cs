using System;
using MyApp.Data.Models;
namespace MyApp.ViewModels
{
	public class CreditsListViewModel
	{
		public IEnumerable<Credit> AllCredits { get; set; }
		public string currentCredit { get; set; }
	}
}

