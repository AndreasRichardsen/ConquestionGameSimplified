using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using ConquestionGame.Presentation.WebClient.ConquestionServiceReference;
using ConquestionGame.Presentation.WebClient.ViewModels;
using System.Web.WebPages.Html;

namespace ConquestionGame.Presentation.WebClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Login", "Account");
        }
    }
}