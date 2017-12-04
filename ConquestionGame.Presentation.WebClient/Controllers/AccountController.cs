using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConquestionGame.Presentation.WebClient.ConquestionServiceReference;

namespace ConquestionGame.Presentation.WebClient.Controllers
{
    public class AccountController : Controller
    {
        public PlayerCredentials PC { get; set; }
        ConquestionServiceClient client = new ConquestionServiceClient();

        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }

        // An instance of player is saved to PC
        [HttpPost]
        public ActionResult Login(Player aPlayer)
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
                }
                else
                {
                    Player player = client.RetrievePlayer(aPlayer.Name);
                    PC.Player = player;
                }
            }
            return RedirectToAction("GetActiveGames", "JoinGame");
        }
    }
}