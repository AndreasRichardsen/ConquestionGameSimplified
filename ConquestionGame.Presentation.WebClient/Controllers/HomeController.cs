using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using ConquestionGame.Presentation.WebClient.ConquestionServiceReference;


namespace ConquestionGame.Presentation.WebClient.Controllers
{
    public class HomeController : Controller
    {
        ConquestionServiceClient client = new ConquestionServiceClient();
        Player currentPlayer = new Player();
        //new dynamic ViewBag = new System.Dynamic.ExpandoObject();
        
      
        //public string ViewBagMessage
        //{
        //    get;
        //    set;
        //}
       

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

       [HttpPost]
        public ActionResult LogIn(Player player)
        {
            
            Player foundPlayer = client.RetrievePlayer(player.Name);
           
            if (!string.IsNullOrEmpty(player.Name))
            {
                if (foundPlayer == null)
                {
                    Player player1 = new Player {Name = player.Name};
                    currentPlayer = player1;
                    client.CreatePlayer(player1);
                    return RedirectToAction("JoinGame", "Home");
                }
                else
                {
                    return RedirectToAction("JoinGame", "Home");
                }
            }
            
            return RedirectToAction("Index", "Home");
        }

        public ActionResult JoinGame()
        {
            List<Game> gamesList = new List<Game>();
            var list = client.ActiveGames();
            //if (list.Length == 0)
            //{
            //   ViewBagMessage = "No active games found!";
            //}
            foreach (var item in list)
            {
                Game game = new Game();
                game.Name = item.Name;
                gamesList.Add(game);
            }
            return View(gamesList);
        }

        [HttpPost]
        public ActionResult CreateGame(Game game)
        {
            
            if (!string.IsNullOrEmpty(game.Name))
            {
                Game aGame = new Game();
                aGame.Name = game.Name;
                //client.AddQuestionSet(aGame, client.RetrieveQuestionSet(1));
                client.AddPlayer(aGame, currentPlayer);

                client.CreateGame(aGame);
            }
            return RedirectToAction("JoinGame", "Home");
        }

        public ActionResult CreateGame()
        {
            return View();
        }
    }
}