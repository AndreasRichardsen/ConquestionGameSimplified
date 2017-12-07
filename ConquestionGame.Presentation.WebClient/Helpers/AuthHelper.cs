using ConquestionGame.Presentation.WebClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConquestionGame.Presentation.WebClient.Helpers
{
    
    public static class AuthHelper
    {
        private static string LoginSessionName = "CurrentPlayer";
        private static LoginViewModel playerCredentials;

        public static LoginViewModel PlayerCredentials
        {
            get
            {
                return HttpContext.Current.Session[LoginSessionName] as LoginViewModel;
            }
            set
            {
                playerCredentials = value;
            }
        }

        public static bool IsLoggedIn()
        {
            return HttpContext.Current.Session[LoginSessionName] != null;
        }

        public static void Login(LoginViewModel loginViewModel)
        {
            HttpContext.Current.Session[LoginSessionName] = loginViewModel;
        }

        public static void Logout()
        {
            HttpContext.Current.Session[LoginSessionName] = null;
        }
    }
}