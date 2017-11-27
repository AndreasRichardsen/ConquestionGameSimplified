using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.ConquestionServiceReference;

namespace UI
{
    //Singleton to retrieve the player information;
    public class PlayerCredentials
    {
        private static PlayerCredentials instance;
        public Player Player { get; set; }

        private PlayerCredentials()
        {

        }

        public static PlayerCredentials Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new PlayerCredentials();
                }
                return instance;
            }
        }
    }
}
