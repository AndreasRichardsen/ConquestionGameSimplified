using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConquestionGame.Presentation.WebClient.ViewModels;
using ConquestionGame.Presentation.WebClient.ConquestionServiceReference;

namespace ConquestionGame.Presentation.WebClient.Controllers
{
    public class QuizController : Controller
    {
         // timer to be implemented later 
        ConquestionServiceClient client = new ConquestionServiceClient();

        QuizViewModel quizVM = new QuizViewModel
        {
            CurrentGame = null,
            CurrentQuestion = null,
            CurrentRound = null,
            PlayerAnswer = new PlayerAnswer
            {
                Player = PlayerCredentials.Instance.Player
            }
        };

        private void InitializeQuiz()
        {
            UpdateGameInfo();
            
        }

        private void UpdateGameInfo()
        {
            GameInstance.Instance.UpdateCurrentGame();
            //RoundInstance.Instance.Round = GameInstance.Instance.Game.Rounds[0];
            quizVM.CurrentGame = GameInstance.Instance.Game;
            quizVM.CurrentRound = quizVM.CurrentGame.Rounds.LastOrDefault();
            quizVM.CurrentQuestion = quizVM.CurrentRound.Question;
    
        }

        // GET: Quiz
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StartQuiz()
        {
            //InitializeQuiz();
            client.StartGame(GameInstance.Instance.Game, PlayerCredentials.Instance.Player);
            return View();
        }
    }
}