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
    public class RoundAction
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime QuestionStartTime { get; set; }
        [DataMember]
        public DateTime MapStartTime { get; set; }
        [DataMember]
        public Question Question { get; set; }
        public Round Round { get; set; }
        [DataMember]
        public List<PlayerAnswer> PlayerAnswers { get; set; }
        [DataMember]
        [ConcurrencyCheck]
        public Player RoundActionWinner { get; set; }
        [DataMember]
        public List<AcquiredMapNode> AcquiredMapNodes { get; set; }
        //[DataMember]
        //public List<AcquiredMapNode> AcquiredMapNodes { get; set; }
    }
}
