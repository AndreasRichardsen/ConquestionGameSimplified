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

        Round CurrentRound = null;

        DateTime startTime;
        private int TimerCountdown = 5;

        public QuizTime()
        {
            InitializeComponent();
            GameInstance.Instance.UpdateCurrentGame();
            CurrentGame = GameInstance.Instance.Game;
            CurrentQuestion = CurrentGame.Rounds.LastOrDefault().Question;
            CurrentRound = CurrentGame.Rounds.LastOrDefault();

            QuestionTextField.Text = CurrentQuestion.Text;

            AnswerButton1.Text = CurrentQuestion.Answers[0].Text;
            AnswerButton2.Text = CurrentQuestion.Answers[1].Text;
            AnswerButton3.Text = CurrentQuestion.Answers[2].Text;
            AnswerButton4.Text = CurrentQuestion.Answers[3].Text;

            PlayerNoLabel.Text = PlayerCredentials.Instance.Player.Name;
            QuestionNoLabel.Text = CurrentRound.RoundNo.ToString();

            startTime = DateTime.Now;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            int elaspedSeconds = (int)(DateTime.Now - startTime).TotalSeconds;
            int remainingSeconds = TimerCountdown - elaspedSeconds;
            StatusLabel.Text = String.Format("{0}", remainingSeconds);

            if(remainingSeconds <= 0 )
            {
                timer1.Stop();
                // code to show correct answers here 

                // code to start next round 
            }
        }

        private void QuizTime_Load(object sender, EventArgs e)
        {
            timer1.Interval = (1 * 1000);
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }
    }
}
