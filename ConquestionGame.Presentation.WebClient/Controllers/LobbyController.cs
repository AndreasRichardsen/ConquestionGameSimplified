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

        // GET: Lobby
        public ActionResult Index()
        {
            return View();
        }
    
        public ActionResult DisplayLobby()
        {
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