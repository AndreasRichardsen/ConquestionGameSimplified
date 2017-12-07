using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConquestionGame.Presentation.WebClient.ConquestionServiceReference;

namespace ConquestionGame.Presentation.WebClient.Controllers
{
    public class JoinGameController : Controller
    {
        ConquestionServiceClient client = new ConquestionServiceClient();

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
            return View();
        }

        // Creates a new game using the game name given by the player
        [HttpPost]
        public ActionResult CreateNewGame(Game aGame)
        {
            Game ourGame = new Game();
            if (!string.IsNullOrEmpty(aGame.Name))
            {
                ourGame.Name = aGame.Name;
                client.CreateGame(ourGame);
            }

            Game gameEntity = client.ChooseGame(aGame.Name, true);
            GameInstance.Instance.Game = gameEntity;

            client.AddPlayer(gameEntity, PlayerCredentials.Instance.Player);

            return RedirectToAction("ChooseQS", "JoinGame");
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
            client.AddPlayer(game, PlayerCredentials.Instance.Player);

            Game gameEntity = client.ChooseGame(game.Name, true);
            GameInstance.Instance.Game = gameEntity;

            return RedirectToAction("DisplayLobby", "Lobby");
        }
    }
}