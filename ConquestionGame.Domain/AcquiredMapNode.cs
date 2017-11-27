using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConquestionGame.Domain
{
    [DataContract]
    public class AcquiredMapNode
    {
        [Key, Column(Order = 0)]
        public int RoundActionId { get; set; }
        [DataMember]
        public RoundAction RoundAction { get; set; }
        [Key, Column(Order = 1)]
        public int MapNodeId { get; set; }
        [DataMember]
        public MapNode MapNode { get; set; }

        [DataMember]
        public Player Player { get; set; }
    }
}
