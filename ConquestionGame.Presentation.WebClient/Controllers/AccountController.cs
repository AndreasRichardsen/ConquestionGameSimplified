using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using ConquestionGame.Presentation.WebClient.ViewModels;
using ConquestionGame.Presentation.WebClient.Helpers;

namespace ConquestionGame.Presentation.WebClient.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            ServicePointManager.ServerCertificateValidationCallback = (obj, certificate, chain, errors) => true;
            bool canLogIn = false;
            using(var authServ = ServiceHelper.GetAuthServiceClient())
            {
                canLogIn = authServ.Login(loginViewModel.Username, loginViewModel.Password);
            }

            if (canLogIn)
            {
                // Sets the current HTTP context to the valid credentials provided
                AuthHelper.Login(loginViewModel);
                return RedirectToAction("GetActiveGames", "JoinGame");
            }
            else
            {
                ViewBag.StatusMessage = "Could not log in. Invalid Credentials.";
                return View("Login");
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public ActionResult Register(RegisterPlayerViewModel pvm)
        {
            ServicePointManager.ServerCertificateValidationCallback = (obj, certificate, chain, errors) => true;
            using (var authServ = ServiceHelper.GetAuthServiceClient())
            {
                try
                {
                    var newPlayer = new ConquestionGame.Presentation.WebClient.AuthenticationServiceReference.Player { Name = pvm.Username };
                    authServ.RegisterPlayer(newPlayer, pvm.Email, pvm.Password);
                    ViewBag.StatusMessage = String.Format("Successfully registered {0}", pvm.Username);
                }
                catch (Exception e)
                {
                    ViewBag.StatusMessage = e.Message;
                }
            }
            return View("Register");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();
            AuthHelper.Logout();
            return RedirectToAction("Login", "Account");
        }
    }
}