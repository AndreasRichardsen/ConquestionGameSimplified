using ConquestionGame.Presentation.WebClient.ConquestionServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConquestionGame.Presentation.WebClient.ViewModels
{
    public class CreateGameViewModel
    {
        public Game Game { get; set; }

        public List<QuestionSet> QuestionSets = new List<QuestionSet>();

        public CreateGameViewModel()
        {
           
        }
    }
}