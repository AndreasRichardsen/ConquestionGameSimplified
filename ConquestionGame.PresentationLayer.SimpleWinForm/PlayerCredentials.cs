using ConquestionGame.PresentationLayer.SimpleWinForm.ConquestionServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquestionGame.PresentationLayer.SimpleWinForm
{
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
                if (instance == null)
                {
                    instance = new PlayerCredentials();
                }
                return instance;
            }
        }
    }
}
