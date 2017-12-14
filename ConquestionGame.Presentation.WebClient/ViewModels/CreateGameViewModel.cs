using ConquestionGame.Presentation.WebClient.ConquestionServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConquestionGame.Presentation.WebClient.ViewModels
{
    public class CreateGameViewModel
    {
        public Game Game { get; set; }

        public List<QuestionSet> QuestionSets { get; set; }

        public int SelectedQuestionSetID { get; set; }
    }
}