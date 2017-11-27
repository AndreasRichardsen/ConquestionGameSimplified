using ConquestionGame.PresentationLayer.SimpleWinForm.ConquestionServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ConquestionGame.PresentationLayer.SimpleWinForm
{
    public partial class QuizTime : Form
    {
        ConquestionServiceClient Client = new ConquestionServiceClient();

        Game CurrentGame = null;

        Question CurrentQuestion = null;

        public QuizTime()
        {
            InitializeComponent();
            CurrentGame = GameInstance.Instance.Game;
            CurrentQuestion = CurrentGame.QuestionSet.Questions[0];
        }



        private void AnswerButton1_Click(object sender, EventArgs e)
        {

        }

        private void AnswerButton2_Click(object sender, EventArgs e)
        {

        }

        private void AnswerButton3_Click(object sender, EventArgs e)
        {

        }

        private void AnswerButton4_Click(object sender, EventArgs e)
        {

        }
    }
}
