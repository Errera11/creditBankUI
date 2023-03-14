using System;
using MyApp.Data.Interfaces;
using MyApp.Data.Models;
using MyApp.Data;

namespace MyApp.Data
{
	public class CreditRepository : ICredit
	{
		//private readonly MyAppDbContext MyAppDbContext;

  //      public CreditRepository(MyAppDbContext AppDBContent)
		//{
		//	//this.MyAppDbContext = AppDBContent; 
		//}

        //public IEnumerable<Credit> AllCredits => (IEnumerable<Credit>)this.MyAppDbContext.Credit;
        public IEnumerable<Credit> AllCredits => (IEnumerable<Credit>)new List<Credit>();

    }
}

