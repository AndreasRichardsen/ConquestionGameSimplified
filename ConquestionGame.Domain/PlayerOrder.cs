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
    public class PlayerOrder
    {
        [Key, Column(Order = 0)]
        public int GameId { get; set; }
        [DataMember]
        public Game Game { get; set; }

        [Key, Column(Order = 1)]
        public int PlayerId { get; set; }
        [DataMember]
        public Player Player { get; set; }

        [DataMember]
        public int Position { get; set; }

    }
}
