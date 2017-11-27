using ConquestionGame.PresentationLayer.SimpleWinForm.ConquestionServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquestionGame.PresentationLayer.SimpleWinForm
{
    class CurrentRound
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
