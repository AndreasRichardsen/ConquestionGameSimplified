using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConquestionGame.Presentation.WebClient.ConquestionServiceReference;
using ConquestionGame.Presentation.WebClient.Helpers;
using ConquestionGame.Presentation.WebClient.ViewModels;

namespace ConquestionGame.Presentation.WebClient.Controllers
{
    public class JoinGameController : Controller
    {
        LoginViewModel loginViewModel = AuthHelper.PlayerCredentials;

        // Gets a list of active games from the db to be displayed on the view
        public ActionResult GetActiveGames()
        {
            using (var client = ServiceHelper.GetServiceClientWithCredentials(loginViewModel.Username, loginViewModel.Password))
            {
                List<Game> listOfGames = new List<Game>();
                var games = client.RetrieveActiveGames();
                foreach (var game in games)
                {
                    Game aGame = new Game
                    {
                        Name = game.Name
                    };
                    listOfGames.Add(aGame);
                }

                return View(listOfGames);
            }

        }

        [HttpGet]
        public ActionResult CreateNewGame()
        {
            using (var client = ServiceHelper.GetServiceClientWithCredentials(loginViewModel.Username, loginViewModel.Password))
            {
                List<QuestionSet> questionSet = new List<QuestionSet>();
                var qs = client.RetrieveAllQuestionSets().ToList();
                CreateGameViewModel viewModel = new CreateGameViewModel();
                viewModel.QuestionSets = qs;

                return View(viewModel); 
            }
        }

        [HttpPost]
        public ActionResult CreateNewGame(CreateGameViewModel viewModel)
        {
            using (var client = ServiceHelper.GetServiceClientWithCredentials(loginViewModel.Username, loginViewModel.Password))
            {
                Game ourGame = new Game();
                if (viewModel != null)
                {
                    ourGame = viewModel.Game;
                    ourGame.QuestionSet = client.RetrieveQuestionSet(viewModel.SelectedQuestionSetID);
                    client.CreateGame(ourGame);
                }

                Game gameEntity = client.RetrieveGame(viewModel.Game.Name, true);
                GameInstance.Instance.Game = gameEntity;

                //gameEntity.QuestionSet = viewModel.QuestionSets.


                client.AddPlayer(gameEntity);

                return RedirectToAction("GetActiveGames", "JoinGame"); 
            }
        }

        [HttpGet]
        public ActionResult ChooseQS()
        {
            using (var client = ServiceHelper.GetServiceClientWithCredentials(loginViewModel.Username, loginViewModel.Password))
            {
                List<QuestionSet> questionSet = new List<QuestionSet>();
                var qs = client.RetrieveAllQuestionSets().ToList();
                foreach (var aQuestionSet in qs)
                {
                    QuestionSet aQS = new QuestionSet
                    {
                        Title = aQuestionSet.Title,
                        Description = aQuestionSet.Description
                    };
                    questionSet.Add(aQS);
                }
                return View(questionSet); 
            }
        }


        public ActionResult AddQuestionSetToGame(string title)
        {
            using (var client = ServiceHelper.GetServiceClientWithCredentials(loginViewModel.Username, loginViewModel.Password))
            {
                QuestionSet qs = new QuestionSet();
                qs = client.RetrieveQuestionSetByTitle(title);
                client.AddQuestionSet(GameInstance.Instance.Game, qs);
                return RedirectToAction("GetActiveGames", "JoinGame"); 
            }
        }

        public ActionResult JoinGame(string name)
        {
            using (var client = ServiceHelper.GetServiceClientWithCredentials(loginViewModel.Username, loginViewModel.Password))
            {
                Game game = client.RetrieveGame(name, false);
                client.AddPlayer(game);

                Game gameEntity = client.RetrieveGame(game.Name, true);
                GameInstance.Instance.Game = gameEntity;

                return RedirectToAction("DisplayLobby", "Lobby"); 
            }
        }
    }
}