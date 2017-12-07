using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConquestionGame.Presentation.WebClient.ConquestionServiceReference;
using System.Net;
using ConquestionGame.Presentation.WebClient.ViewModels;
using ConquestionGame.Presentation.WebClient.Helpers;

namespace ConquestionGame.Presentation.WebClient.Controllers
{
    public class AccountController : Controller
    {
        public PlayerCredentials PC { get; set; }
        ConquestionServiceClient client = new ConquestionServiceClient();
       

        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }

        // An instance of player is saved to PC
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
    }
}