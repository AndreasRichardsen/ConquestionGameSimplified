using ConquestionGame.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConquestionGame.WCFServiceLibrary
{
    [ServiceContract]
    public interface IAuthenticationService
    {
        [OperationContract]
        bool Login(string userName, string password);

        [OperationContract]
        Player RegisterPlayer(Player player, string email, string password);
    }
}
