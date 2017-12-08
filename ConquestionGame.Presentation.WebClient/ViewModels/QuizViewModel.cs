using ConquestionGame.Presentation.WebClient.ConquestionServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConquestionGame.Presentation.WebClient.ViewModels
{
    public class QuizViewModel
    {
        public Game CurrentGame { get; set; }

        public Question CurrentQuestion { get; set; }

        public Round CurrentRound { get; set; }

        public PlayerAnswer PlayerAnswer { get; set; }

        public bool HasAnswered { get; set; }
    }
}