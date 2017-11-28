using ConquestionGame.Presentation.WinForm.ConquestionServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquestionGame.Presentation.WinForm
{
    class GameInstance
    {
        private static GameInstance instance;
        ConquestionServiceClient client = new ConquestionServiceClient();
        public Game Game { get; set; }

        private GameInstance()
        {

        }

        public static GameInstance Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameInstance();
                }
                return instance;
            }
        }

        public void UpdateCurrentGame()
        {
            Game gameEntity = client.ChooseGame(Game.Name, true);
            Game = gameEntity;
        }
    }
}
