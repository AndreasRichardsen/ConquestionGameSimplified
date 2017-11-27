using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConquestionGame.Domain
{
    [DataContract]
    public class MapNode
    {
        [DataMember]
        public int Id { get; set; }

        public int MapId { get; set; }

        public Map Map { get; set; }

        public List<MapNode> NeighbouringNodes { get; set; }
        //These two lists are for making the junkion table
        public List<MapNode> NeighboringNodes { get; set; }

        public List<MapNodeOwner> MapNodeOwners { get; set; }
    }
}
