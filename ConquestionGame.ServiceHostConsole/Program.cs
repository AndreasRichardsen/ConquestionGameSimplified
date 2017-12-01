using ConquestionGame.WCFServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConquestionGame.ServiceHostConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(ConquestionService));
            //ServiceHost authHost = new ServiceHost(typeof(AuthenticationService));
            host.Open();
            Console.WriteLine("Running Conquestion service host...");
            //authHost.Open();
            Console.WriteLine("Running authentication service...");
            Console.ReadLine();
            host.Close();
            //authHost.Close();
        }
    }
}
