using ConquestionGame.DataAccessLayer;
using ConquestionGame.Domain;
using System.Linq;
using System.Security.Permissions;

namespace ConquestionGame.LogicLayer
{
    public class PlayerController
    {
        public Player CreatePlayer(Player player)
        {
            using (var db = new ConquestionDBContext())
            {
                db.Players.Add(player);
                db.SaveChanges();
                return player; 
            }
        }

        public Player RetrievePlayer(string name)
        {
            using (ConquestionDBContext db = new ConquestionDBContext())
            {
                return db.Players.Where(p => p.Name.Equals(name)).FirstOrDefault();
            }
        }
    }
}
