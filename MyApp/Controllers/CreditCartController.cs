using System;
using Microsoft.AspNetCore.Mvc;
//using MyApp.Data.Repository;
using MyApp.Data.Interfaces;
using MyApp.Data.Models;
using MyApp.ViewModels;
namespace MyApp.Controllers
{
    public class CreditCartController : Controller
    {
        private readonly ICredit _creditRep; // may be error
        private readonly CreditCart _creditCart;
        private readonly AuthModel user;

        public CreditCartController(ICredit creditRep, CreditCart creditCart, AuthModel user)
        {
            this.user = user;
            _creditRep = creditRep;
            _creditCart = creditCart;
        }
        //[Route("CreditCart/Index")]
        public ViewResult Index()
        {
            //var items = _creditCart.GetClientCredits();
            //_creditCart.ClientCreditsList = items;


            if (_creditCart.ClientCredit?.id == 0  && _creditCart.ClientCredit?.isConfirmed == -1)
            {

                CreditCartViewModel obj = new CreditCartViewModel() {
                    creditCart = new CreditCart() };
                return View(obj);
            }
            CreditCartViewModel objEr = new CreditCartViewModel() { creditCart = _creditCart };
            return View(objEr);

            //var obj = new CreditCart() { CreditCart = _creditCart };


        }
        public RedirectToActionResult addToCart(int id)
        {
            //var item = _creditRep.AllCredits.FirstOrDefault(i => i.id == id);
            var item = _creditRep.AllCredits.FirstOrDefault(i => i.id == id);
            if (_creditCart.ClientCredit?.isConfirmed == 0
                | _creditCart.ClientCredit?.isConfirmed == -1)
			{
                _creditCart.AddCredit(item);
                //this.user.clientCredit = new ClientCredit();
                //this.user.clientCredit.CreditTime = item.creditTime;
                //this.user.clientCredit.Percentage = item.percentage;
                //this.user.clientCredit.RemainingAmount = item.amount;
                //this.user.clientCredit.RemainingAmountToPay = item.amount;
            }
			return RedirectToAction("Index");
		}

        public RedirectToActionResult CreditAction(CreditAction x)
        {
            if(this._creditCart.ClientCredit.RemainingAmount - x.withdrawValue > -1)
            {
                this._creditCart.ClientCredit.RemainingAmount -= x.withdrawValue;
            }
            if (this._creditCart.ClientCredit.RemainingAmountToPay - x.depositValue > -1)
            {
                this._creditCart.ClientCredit.RemainingAmountToPay -= x.depositValue;
            }

            if(this._creditCart.ClientCredit.RemainingAmount - x.withdrawValue < 2 &&
                this._creditCart.ClientCredit.RemainingAmountToPay - x.depositValue < 2)
            {
                this._creditCart.ClientCredit.id = 0;
            }
            return RedirectToAction("Index");
        }
        
    }
}

