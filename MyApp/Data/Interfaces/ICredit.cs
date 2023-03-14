using System;
using MyApp.Data.Interfaces;
using MyApp.Data.Models;
namespace MyApp.Data.Interfaces
{
	public interface ICredit
	{
		IEnumerable<Credit> AllCredits { get; }
	}
}

