using ConquestionGame.LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConquestionGame.WCFServiceLibrary.PlayerValidation
{
    public class RoleValidator :ServiceAuthorizationManager
    {
        PlayerController playerCtr = new PlayerController();
        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            var identity = operationContext.ServiceSecurityContext.PrimaryIdentity;
            var foundPlayer = playerCtr.RetrievePlayer(identity.Name);
            string[] roles = { "Player" };
            if (foundPlayer == null)
            {
                throw new Exception("User not found");
            }
            else
            {
                var principal = new GenericPrincipal(identity, roles);
                operationContext.ServiceSecurityContext.AuthorizationContext.Properties["Principal"] = principal;
                return true;
            }
        }
    }
}
