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
        ConquestionServiceClient client = new ConquestionServiceClient();

        Game CurrentGame = null;
        Round CurrentRound = null;
        Question CurrentQuestion = null;
        PlayerAnswer PlayerAnswer = new PlayerAnswer { Player = PlayerCredentials.Instance.Player };

        public ActionResult StartQuiz()
        {
            client.StartGame(GameInstance.Instance.Game, PlayerCredentials.Instance.Player);
      
            GameInstance.Instance.UpdateCurrentGame();
            RoundInstance.Instance.Round = GameInstance.Instance.Game.Rounds[0];

            return RedirectToAction("UniversalQuiz", "Quiz");
        }

        [HttpGet]
        public ActionResult UniversalQuiz()
        {
            UpdateGameInformation();

            QuizViewModel quizVM = new QuizViewModel
            {
                CurrentGame = CurrentGame,
                CurrentQuestion = CurrentQuestion,
                CurrentRound = CurrentRound
            };

            return View(quizVM);
        } 

        private void UpdateGameInformation()
        {
            GameInstance.Instance.UpdateCurrentGame();
            CurrentGame = GameInstance.Instance.Game;
            CurrentRound = CurrentGame.Rounds.LastOrDefault();
            CurrentQuestion = CurrentRound.Question;
        }

        public ActionResult AnswerSelected(int id)
        {
            UpdateGameInformation();

            if(id!=0)
            {
                Answer playerAnswer = new Answer();
                foreach (Answer answer in CurrentQuestion.Answers)
                {
                    if (answer.Id == id)
                    {
                        playerAnswer = answer;
                    }
                }
                PlayerAnswer.AnswerGiven = playerAnswer;
                client.SubmitAnswer(CurrentRound, PlayerAnswer);
            }



            //CheckIfPlayers();
            client.CreateRound(CurrentGame);

            Answer correctAnswer = new Answer();

            foreach (Answer answer in CurrentQuestion.Answers)
            {
                if (client.ValidateAnswer(answer) == true)
                {
                    correctAnswer = answer;
                    ViewBag.CorrectAnswerId = answer.Id;
                }
            }

            Player roundWinner = client.GetRoundWinner(CurrentRound);
            if (roundWinner != null)
            {
                ViewBag.Status = String.Format("  Round Winner: {0}!", roundWinner.Name);
            }
            else
            {
                ViewBag.Status = String.Format("  No winner this time!");
            }

            QuizViewModel quizVM = new QuizViewModel
            {
                CurrentGame = CurrentGame,
                CurrentQuestion = CurrentQuestion,
                CurrentRound = CurrentRound
            };

            return View(quizVM);
        }

        private void CheckIfPlayers()
        {
            UpdateGameInformation();
            bool playersAnswered = client.CheckIfAllPlayersAnswered(CurrentGame, CurrentRound);
            if (playersAnswered)
            {
                if (PlayerCredentials.Instance.Player.Id == CurrentGame.Players.FirstOrDefault().Id)
                {
                    client.CreateRound(CurrentGame);
                }
            }
        }
    }
}