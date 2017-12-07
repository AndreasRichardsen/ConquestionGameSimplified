using ConquestionGame.Presentation.WebClient.ConquestionServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConquestionGame.Presentation.WebClient.Controllers
{
    public class LobbyController : Controller
    {
        ConquestionServiceClient client = new ConquestionServiceClient();

        Game CurrentGame = new Game();

        // GET: Lobby
        public ActionResult Index()
        {
            return View();
        }

        private void Setup()
        {
            CurrentGame = GameInstance.Instance.Game;
            ViewBag.GameName = CurrentGame.Name;
            ViewBag.QSName = CurrentGame.QuestionSet.Title;
            ViewBag.QSDescription = CurrentGame.QuestionSet.Description;
            CheckIfLobbyHost();
        }

        private void CheckIfLobbyHost()
        {
            if (GameInstance.Instance.Game != null)
            {
                var gameEntity = client.ChooseGame(GameInstance.Instance.Game.Name, true);
                if (PlayerCredentials.Instance.Player.Name.Equals(gameEntity.Players[0].Name))
                {
                    ViewBag.IsHost = true;
                }
                else
                {
                    ViewBag.IsHost = false;
                }
            }
        }

        [HttpGet]
        public ActionResult DisplayLobby()
        {
            Setup();
            Game aGame = GameInstance.Instance.Game;
            var listOfPlayers = new List<Player>();
            try
            {
                listOfPlayers = aGame.Players.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("error", e);
            }
            return View(listOfPlayers);
        }
    }
}