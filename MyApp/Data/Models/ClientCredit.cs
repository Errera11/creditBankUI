using System;
namespace MyApp.Data.Models
{
	public class ClientCredit
	{
		public int id { get; set; }
        public int RemainingAmount { get; set; }
        public int RemainingAmountToPay { get; set; }
		public int Percentage { get; set; }
		public int CreditTime { get; set; }
		public int isConfirmed { get; set; }
	}
}

