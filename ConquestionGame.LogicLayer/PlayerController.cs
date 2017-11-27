using ConquestionGame.DataAccessLayer;
using ConquestionGame.Domain;
using System.Linq;

namespace ConquestionGame.LogicLayer
{
    public class PlayerController
    {
        ConquestionDBContext db = new ConquestionDBContext();
        public Player CreatePlayer(Player player)
        {
            db.Players.Add(player);
            db.SaveChanges();
            return player;
        }

        public Player RetrievePlayer(string name)
        {
            var playerEntity = new Player();
            playerEntity = db.Players.Where(p => p.Name.Equals(name)).FirstOrDefault();
            return playerEntity;
        }
    }
}
