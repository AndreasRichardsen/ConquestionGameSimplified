using ConquestionGame.Domain;
using ConquestionGame.LogicLayer;
using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConquestionGame.WCFServiceLibrary.PlayerValidation
{
    public class CredentialValidator : UserNamePasswordValidator
    {
        PlayerController playerCtr = new PlayerController();
        public override void Validate(string userName, string password)
        {
            Player foundPlayer = playerCtr.RetrievePlayer(userName);
            if (foundPlayer != null && foundPlayer.Name.Equals(userName) && SecurePasswordHelper.VerifyPassword(password, foundPlayer.HashedPassword))
            {
                
            }
            else
            {
                throw new FaultException<Exception>(new Exception("Invalid login..."), "Invalid credentials");
            }
        }
    }
}
