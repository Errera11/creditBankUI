using System;
using Microsoft.AspNetCore.Mvc;
using MyApp.Data.Interfaces;
using MyApp.ViewModels;

namespace MyApp.Controllers
{
	public class CreditsController : Controller
	{
		private readonly ICredit AllCredits;
        public CreditsController(ICredit credits)
		{
			this.AllCredits = credits; 
		}
		//[Route("Credits/List")]
		public ViewResult List()
		{
			ViewBag.Title = "My App"; 
            CreditsListViewModel obj = new CreditsListViewModel();
			obj.AllCredits = this.AllCredits.AllCredits;
			obj.currentCredit = "You can apply credits: ";
            return View(obj);
		}
    }
}

