using System;
using Microsoft.AspNetCore.Mvc;
using MyApp.Data.Models;
using MyApp.Data.Interfaces;
using MyApp.Data.Repository;
using MyApp.ViewModels;

namespace MyApp.Controllers
{
	public class ApplyCreditController : Controller
	{
		private CreditCart creditCart;
		private ApplyCredit ApplyCredit;
        private ClientCredit clientCredit;
        private AuthModel user;
        AuthRep authRep;

        public ApplyCreditController(ApplyCredit ApplyCredit,
            CreditCart creditCart,
            ClientCredit clientCredit,
            AuthModel user,
            AuthRep authRep
            )
        {
			this.ApplyCredit = ApplyCredit;
			this.creditCart = creditCart;
            this.clientCredit = clientCredit;
            this.user= user;
            this.authRep = authRep;
        }

		public IActionResult Confirm()
		{
            this.creditCart.ClientCredit.isConfirmed = 1;
            this.user.clientCredit.isConfirmed = 1;

            return RedirectToAction("IsConfirmed");
        }

        public IActionResult Deny()
        {
            this.creditCart.ClientCredit.isConfirmed = -1;
            this.user.clientCredit.isConfirmed = -1;
            return RedirectToAction("IsConfirmed");
        }

        [HttpPost]
        public IActionResult Checkout(ApplyCredit x)
        {
			if (ModelState.IsValid)
			{
				this.ApplyCredit.name = x.name;
                this.ApplyCredit.lastname = x.lastname;
                this.ApplyCredit.age = x.age;
                this.ApplyCredit.income = x.income;
                this.ApplyCredit.job = x.job;

                this.user.Login = x.login;
                this.user.Password = x.password;
                this.user.clientCredit = this.creditCart.ClientCredit;

                

                return RedirectToAction("CreditConfirmation"); 
			}
            else if (ModelState.IsValid && this.user.Login?.Length > 0)
            {
                return RedirectToAction("CreditConfirmation");
            }
            return View();
        }

        
        public IActionResult Checkout()
        {
            return View();
        }


        public IActionResult IsConfirmed()
        {
            int cond = this.creditCart.ClientCredit.isConfirmed;
            this.user.clientCredit = this.creditCart.ClientCredit;
            return View(cond);
        }

        public IActionResult CreditConfirmation()
        {
            ApplyCreditViewModel obj = new ApplyCreditViewModel()
            {
                clientCredit = this.creditCart.ClientCredit,
                applyCredit = this.ApplyCredit
            };
            return View(obj);
        }
    }
}

