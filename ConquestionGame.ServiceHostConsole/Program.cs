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
            using (ServiceHost host = new ServiceHost(typeof(ConquestionService)))
            {
                host.Open();
                Console.WriteLine("Running Conquestion service host...");

                Console.ReadLine();
            }
        }
    }
}
