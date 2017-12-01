using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using ConquestionGame.Presentation.WebClient.ConquestionServiceReference;
using ConquestionGame.Presentation.WebClient.ViewModels;

namespace ConquestionGame.Presentation.WebClient.Controllers
{
    public class HomeController : Controller
    {
        public PlayerCredentials PC { get; set; }
      
        ConquestionServiceClient client = new ConquestionServiceClient();

       
    
        public ActionResult Index()
        {
            return RedirectToAction("Login", "Home");
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Player aPlayer)
        {
            PC = PlayerCredentials.Instance;
            
            Player foundPlayer = new Player();
            foundPlayer = client.RetrievePlayer(aPlayer.Name);
            if (!string.IsNullOrEmpty(aPlayer.Name))
            {
                if (foundPlayer == null)
                {
                    Player ourPlayer = new Player()
                    {
                        Name = aPlayer.Name
                    };

                    client.CreatePlayer(ourPlayer);
                    Player player = client.RetrievePlayer(aPlayer.Name);
                    PC.Player = player;
                    // ourplayer has id 0
                }
                else
                {
                    PC.Player = foundPlayer;
                }
            }
            return RedirectToAction("DisplayActiveGames", "Home");
        }

        public ActionResult JoinGame(string name)
        {
            Game game = client.ChooseGame(name, false);
            client.AddPlayer(game, PlayerCredentials.Instance.Player);

            Game gameEntity = client.ChooseGame(game.Name, true);
            GameInstance.Instance.Game = gameEntity;

            return RedirectToAction("DisplayLobby", "Home");
        }

        public ActionResult DisplayLobby()
        {
            Game aGame = GameInstance.Instance.Game;
            var listOfPlayers = new List<Player>();
            try
            {
                listOfPlayers = aGame.Players.ToList();
            }
            catch(Exception e)
            {
                Console.WriteLine("error", e);
            }
            return View(listOfPlayers);
        }

        public ActionResult DisplayActiveGames()
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
            return View(listOfGames);
        }

        [HttpPost]
        public ActionResult CreateGame(Game aGame)
        {
            Game ourGame = new Game();
            if (!string.IsNullOrEmpty(aGame.Name))
            {
                ourGame.Name = aGame.Name;
                client.CreateGame(ourGame);

            }

            Game game = client.ChooseGame(aGame.Name,false);
            var qs = client.RetrieveQuestionSet(1);

            var questionSets = client.RetrieveAllQuestionSets();

            client.AddQuestionSet(game, qs);
            client.AddPlayer(game, PlayerCredentials.Instance.Player);

            //return View();
            return RedirectToAction("DisplayActiveGames", "Home");
        }

        public ActionResult CreateGame()
        {
            return View();
        }

    }
}