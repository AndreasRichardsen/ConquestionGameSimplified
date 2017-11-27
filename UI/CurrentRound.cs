using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.ConquestionServiceReference;

namespace UI
{
    //Singleton to retrieve the Game information;
    public class CurrentRound
    {
        private static CurrentRound instance;
        public Round Round { get; set; }

        private CurrentRound()
        {

        }

        public static CurrentRound Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CurrentRound();
                }
                return instance;
            }
        }
    }
}
