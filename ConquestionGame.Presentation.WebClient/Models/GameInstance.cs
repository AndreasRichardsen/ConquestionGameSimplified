using ConquestionGame.Presentation.WebClient.ConquestionServiceReference;
using ConquestionGame.Presentation.WebClient.Helpers;
using ConquestionGame.Presentation.WebClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquestionGame.Presentation.WebClient
{
    class GameInstance
    {
        private static GameInstance instance;
        static LoginViewModel loginViewModel = AuthHelper.PlayerCredentials;
        ConquestionServiceClient client = ServiceHelper.GetServiceClientWithCredentials(loginViewModel.Username, loginViewModel.Password);
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
