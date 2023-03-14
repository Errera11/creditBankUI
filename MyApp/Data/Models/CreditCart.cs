using System;
using Microsoft.AspNetCore.Http;
using MyApp.Data;

namespace MyApp.Data.Models
{
    public class CreditCart
    {
        //private readonly MyAppDbContext MyAppDbContext;

        public CreditCart(/*MyAppDbContext AppDBContent*/)
        {
            //this.MyAppDbContext = AppDBContent;a
            ClientCredit = new ClientCredit();
        }

        //public string CreditCartId { get; set; }

        public ClientCredit ClientCredit { get; set; }

        //      public static CreditCart GetCart(IServiceProvider services)
        //{
        //	ISession session = services.GetService<IHttpContextAccessor>()?.HttpContext.Session;
        //	var context = services.GetService<AppDBContent>();
        //	string creditCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

        //	session.SetString("CartId", creditCartId);

        //	return new CreditCart(context) { CreditCartId = creditCartId };
        //}

        public void AddCredit(Credit credit)
        {
            //this.AppDBContent.ClientCredit.Add(
            //	new ClientCredit
            //	{
            //		id = 1,
            //		RemainingAmount = credit.amount,
            //		RemainingAmountToPay = credit.amount,
            //		CreditTime = credit.creditTime
            //	});
            //         AppDBContent.SaveChanges();
            this.ClientCredit =
                         new ClientCredit
                         {
                             id = credit.id,
                             RemainingAmount = credit.amount,
                             RemainingAmountToPay = credit.amount,
                             CreditTime = credit.creditTime,
                             Percentage = credit.percentage
                             
                         };
        }

        public ClientCredit GetClientCredits()
        {
            //return AppDBContent.ClientCredit.ToList();
            return this.ClientCredit;
        }
    }
}

