using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConquestionGame.Domain
{
    [DataContract]
    public class MapNodeOwner
    {
        [DataMember]
        public int GameId { get; set; }
        [DataMember]
        public Game Game { get; set; }
        [DataMember]
        public int MapNodeId { get; set; }
        [DataMember]
        public MapNode MapNode {get;set; }
        [DataMember]
        public Player Player { get; set; }
    }
}
