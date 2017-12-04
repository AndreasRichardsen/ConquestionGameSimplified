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
    public class Round
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int RoundNo { get; set; }
        [DataMember]
        public DateTime QuestionStartTime { get; set; }

        [DataMember]
        public Question Question { get; set; }
  
        [DataMember]
        public List<PlayerAnswer> PlayerAnswers { get; set; }
        [DataMember]
        [ConcurrencyCheck]
        public Player RoundWinner { get; set; }

        public Game Game { get; set; }

    }
}
