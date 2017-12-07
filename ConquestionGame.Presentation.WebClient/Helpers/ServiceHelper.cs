using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConquestionGame.Presentation.WebClient.ConquestionServiceReference;
using ConquestionGame.Presentation.WebClient.AuthenticationServiceReference;

namespace ConquestionGame.Presentation.WebClient.Helpers
{
    public static class ServiceHelper
    {
        public static ConquestionServiceClient GetServiceClientWithCredentials(string username, string password)
        {
            ConquestionServiceClient client = new ConquestionServiceClient();
            client.ClientCredentials.UserName.UserName = username;
            client.ClientCredentials.UserName.Password = password;
            return client;
        }

        public static AuthenticationServiceClient GetAuthServiceClient()
        {
            return new AuthenticationServiceClient();
        }
    }
}