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
        static LoginViewModel loginViewModel = AuthHelper.PlayerCredentials;
        ConquestionServiceClient client = ServiceHelper.GetServiceClientWithCredentials(loginViewModel.Username, loginViewModel.Password);

        // Gets a list of active games from the db to be displayed on the view
        public ActionResult GetActiveGames()
        {
            List<Game> listOfGames = new List<Game>();
            var games = client.ActiveGames();
            foreach (var game in games)
            {
                Game aGame = new Game
                {
                    Name = game.Name
                };
                listOfGames.Add(aGame);
            }

            try
            {
                ViewBag.PlayerName = PlayerCredentials.Instance.Player.Name;
            }
            catch(Exception e)
            {
                Console.WriteLine("error", e);
            }
            
            return View(listOfGames);
        }

        [HttpGet]
        public ActionResult CreateNewGame()
        {
            List<QuestionSet> questionSet = new List<QuestionSet>();
            var qs = client.RetrieveAllQuestionSets().ToList();
            CreateGameViewModel viewModel = new CreateGameViewModel();
            viewModel.QuestionSets = qs;

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateNewGame(CreateGameViewModel viewModel)
        {
            Game ourGame = new Game();
            if (viewModel != null)
            {
                ourGame = viewModel.Game;
                ourGame.QuestionSet = client.RetrieveQuestionSet(viewModel.SelectedQuestionSetID);
                client.CreateGame(ourGame);
            }

            Game gameEntity = client.ChooseGame(viewModel.Game.Name, true);
            GameInstance.Instance.Game = gameEntity;

            //gameEntity.QuestionSet = viewModel.QuestionSets.
         

            client.AddPlayer(gameEntity);

            return RedirectToAction("GetActiveGames", "JoinGame");
        }

        [HttpGet]
        public ActionResult ChooseQS()
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

      
        public ActionResult AddQuestionSetToGame(string title)
        {
            QuestionSet qs = new QuestionSet();
            qs = client.RetrieveQuestionSetByTitle(title);
            client.AddQuestionSet(GameInstance.Instance.Game,qs);
            return RedirectToAction("GetActiveGames", "JoinGame");
        }

        public ActionResult JoinGame(string name)
        {
            Game game = client.ChooseGame(name, false);
            client.AddPlayer(game);

            Game gameEntity = client.ChooseGame(game.Name, true);
            GameInstance.Instance.Game = gameEntity;

            return RedirectToAction("DisplayLobby", "Lobby");
        }
    }
}