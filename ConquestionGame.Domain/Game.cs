﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConquestionGame.Domain
{
    [DataContract]

    public class Game
    {
        public enum GameStatusEnum
        {
            starting=0,
            ongoing=1,
            finished=2
        };
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public List<Player> Players { get; set; }
        [DataMember]
        public GameStatusEnum GameStatus { get; set; }
        [DataMember]
        public QuestionSet QuestionSet { get; set; }
        [DataMember]
        public List<Round> Rounds { get; set; }
        public List<AskedQuestion> QuestionsAsked { get; set; }

        [DataMember]
        [Range(1, 50, ErrorMessage = "Rounds must be between 1 and 50")]
        public int NoOfRounds { get; set; }
    }
}
