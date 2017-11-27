using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.ConquestionServiceReference;

namespace UI
{
   
    //Singleton to retrieve the Game information;
    public class CurrentGame
    {
        private static CurrentGame instance;
        ConquestionServiceClient client = new ConquestionServiceClient();
        public Game Game { get; set; }

        private CurrentGame()
        {

        }

        public static CurrentGame Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CurrentGame();
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
