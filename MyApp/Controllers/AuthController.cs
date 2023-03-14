using System;
using Microsoft.AspNetCore.Mvc;
using MyApp.Data.Models;
using MyApp.Data.Repository;
using MyApp.Data.Models;
using NuGet.Protocol.Plugins;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyApp.Controllers
{
    public class AuthController : Controller
    {
        private AuthRep authRep;
        private CreditCart creditCart;
        public AuthModel user;
        public AuthController(AuthRep authRep, AuthModel user, CreditCart creditCart)
        {
            this.creditCart = creditCart;
            this.authRep = authRep;
            this.user = user;
        }

        [HttpPost]
        public IActionResult Login(AuthModel x)
        {
            for (int i = 0; i < authRep.getUser.Count(); i++)
            {
                var obj = authRep.getUser.ElementAt(i);
                if (obj.Login == x.Login
                    && obj.Password == x.Password)
                {
                    this.user.Login = obj.Login;
                    this.user.Password = obj.Password;
                    this.user.clientCredit = obj.clientCredit;
                    this.creditCart.ClientCredit = this.user.clientCredit;
                    return RedirectToAction("List", "Credits");
                }
            }

            return View();
        }


        public IActionResult Login()
        {
            
            return View();
        }
        public IActionResult Logout()
        {


            if (authRep.getUser.Count() == 0)
            {
                this.authRep.addUser(new Client()
                {
                    Password = this.user.Password,
                    Login = this.user.Login,
                    clientCredit = this.user.clientCredit
                });
            }
                for (int i = 0; i < authRep.getUser.Count(); ++i)
                {
                    var obj = authRep.getUser.ElementAt(i);
                    if (obj.Login != this.user.Login
                        && obj.Password != this.user.Password)
                    {

                        this.authRep.addUser(new Client()
                        {
                            Password = this.user.Password,
                            Login = this.user.Login,
                            clientCredit = this.user.clientCredit
                        });
                    }

                
                    this.user.Login = "";
                    this.user.Password = "";
                    this.user.clientCredit = new ClientCredit();
                    this.creditCart.ClientCredit = new ClientCredit();
                }
            return RedirectToAction("List", "Credits");
        }
    }
}

