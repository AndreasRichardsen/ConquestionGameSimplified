using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConquestionGame.Domain
{
    [DataContract]
    public class PlayerAnswer
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public Player Player { get; set; }
        [DataMember]
        public Answer AnswerGiven { get; set; }
        [DataMember]
        public DateTime PlayerAnswerTime { get; set; }
        public RoundAction RoundAction { get; set; }
    }
}
