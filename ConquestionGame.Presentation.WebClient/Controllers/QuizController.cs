using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConquestionGame.Presentation.WebClient.ViewModels;
using ConquestionGame.Presentation.WebClient.ConquestionServiceReference;
using ConquestionGame.Presentation.WebClient.Helpers;

namespace ConquestionGame.Presentation.WebClient.Controllers
{
    public class QuizController : Controller
    {
        LoginViewModel loginViewModel = AuthHelper.PlayerCredentials;
        
        Game CurrentGame = null;
        Round CurrentRound = null;
        Question CurrentQuestion = null;
        PlayerAnswer PlayerAnswer = new PlayerAnswer { Player = PlayerCredentials.Instance.Player };

        public ActionResult StartQuiz()
        {
            using (var client = ServiceHelper.GetServiceClientWithCredentials(loginViewModel.Username, loginViewModel.Password))
            {
                client.StartGame(GameInstance.Instance.Game);

                GameInstance.Instance.UpdateCurrentGame();
                RoundInstance.Instance.Round = GameInstance.Instance.Game.Rounds[0];

                return RedirectToAction("UniversalQuiz", "Quiz"); 
            }
        }

        [HttpGet]
        public ActionResult UniversalQuiz()
        {
            UpdateGameInformation();

            if(CheckEndCondition() == false)
            {
                QuizViewModel quizVM = new QuizViewModel
                {
                    CurrentGame = CurrentGame,
                    CurrentQuestion = CurrentQuestion,
                    CurrentRound = CurrentRound
                };

                return View(quizVM);
            }
            else
            {
                return RedirectToAction("EndScreen", "Quiz");
            }
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
            using (var client = ServiceHelper.GetServiceClientWithCredentials(loginViewModel.Username, loginViewModel.Password))
            {
                UpdateGameInformation();

                if (id != 0)
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
            }
            return RedirectToAction("ShowCorrectAnswers", "Quiz");
        }

        public ActionResult ShowCorrectAnswers()
        {
            using (var client = ServiceHelper.GetServiceClientWithCredentials(loginViewModel.Username, loginViewModel.Password))
            {
                UpdateGameInformation();

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

                Player roundWinner = client.RetrieveRoundWinner(CurrentRound);
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
        }

        private bool CheckEndCondition()
        {
            using (var client = ServiceHelper.GetServiceClientWithCredentials(loginViewModel.Username, loginViewModel.Password))
            {
                UpdateGameInformation();

                if (client.CheckIfGameIsFinished(CurrentGame))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public ActionResult EndScreen()
        {
            using (var client = ServiceHelper.GetServiceClientWithCredentials(loginViewModel.Username, loginViewModel.Password))
            {
                UpdateGameInformation();

                if(client.DetermineGameWinner(CurrentGame)!=null)
                {
                    ViewBag.Winner = "The winner is: " + client.DetermineGameWinner(CurrentGame).Name;
                }
                else
                {
                    ViewBag.Winner = "You guys suck!";
                }
            }
            return View();
        }
    }
}
