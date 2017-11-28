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
    public class AskedQuestion
    {
        [Key, Column(Order = 0)]
        public int GameId { get; set; }
        [Key, Column(Order = 1)]
        public int QuestionId { get; set; }
        [DataMember]
        public Game Game { get; set; }
        [DataMember]
        public Question Question { get; set; }
        [DataMember]
        public bool HasBeenAsked { get; set; }
    }
}
