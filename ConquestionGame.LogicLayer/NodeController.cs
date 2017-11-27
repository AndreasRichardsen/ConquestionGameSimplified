using ConquestionGame.DataAccessLayer;
using ConquestionGame.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquestionGame.LogicLayer
{
    public class NodeController
    {
        ConquestionDBContext db = new ConquestionDBContext();

        // might be unnecessary
        public bool CheckIfNodeIsFree(Game game, int mapNodeId)
        {
            bool free = false;
            MapNodeOwner Owner = new MapNodeOwner();
            Owner = db.MapNodeOwners.Include("Player").Where(m => m.GameId == game.Id && m.MapNodeId == mapNodeId).FirstOrDefault();
            if (Owner.Player == null)
            {
                free = true;
            }
            return free;
        }

        // returns a player so we can know if a map node is owned or not and by who
        public Player ReturnNodeOwner(Game game, int mapNodeId)
        {
            MapNodeOwner Owner = new MapNodeOwner();
            Owner = db.MapNodeOwners.Include("Player").Where(m => m.GameId == game.Id && m.MapNodeId == mapNodeId).FirstOrDefault();
            return Owner?.Player;
        }
    }
}
