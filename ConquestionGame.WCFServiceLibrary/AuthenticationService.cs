using ConquestionGame.Domain;
using ConquestionGame.LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquestionGame.WCFServiceLibrary
{
    public class AuthenticationService : IAuthenticationService
    {
        PlayerController playerCtr = new PlayerController();
        public bool Login(string userName, string password)
        {
            Player foundPlayer = playerCtr.RetrievePlayer(userName);
            if (foundPlayer != null && foundPlayer.Name.Equals(userName))
            {
                return SecurePasswordHelper.VerifyPassword(password, foundPlayer.HashedPassword);
            }
            else
            {
                return false;
            }
        }
    }
}
