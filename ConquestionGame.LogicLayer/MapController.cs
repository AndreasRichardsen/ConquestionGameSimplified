using ConquestionGame.DataAccessLayer;
using ConquestionGame.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ConquestionGame.LogicLayer
{
    public class MapController
    {
        ConquestionDBContext db = new ConquestionDBContext();

        public Map CreateMap(Map map)
        {
            db.Maps.Add(map);
            db.SaveChanges();
            return map;
        }

        public Map ChooseMap(string name)
        {
            Map chosenMap = new Map();

            chosenMap = db.Maps.
                Where(m => m.Name.Equals(name)).
                FirstOrDefault();
            return chosenMap;
        }

        public List<Map> RetrieveAllMaps()
        {
            List<Map> maps = new List<Map>();
            maps = db.Maps.ToList();
            return maps;
        }

    }
}
