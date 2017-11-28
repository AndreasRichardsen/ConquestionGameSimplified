using ConquestionGame.Presentation.WinForm.ConquestionServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ConquestionGame.Presentation.WinForm
{
    public partial class QuizTime : Form
    {
        ConquestionServiceClient Client = new ConquestionServiceClient();

        Game CurrentGame = null;
        Question CurrentQuestion = null;
        Round CurrentRound = null;
        PlayerAnswer PlayerAnswer = new PlayerAnswer { Player = PlayerCredentials.Instance.Player };

        List<Button> AnswerButtons;

        DateTime startTime;
        private int TimerCountdown = 30;
        bool TimerCountdownCanRun = true;
        private int AnswerViewingTime = 5;
        bool AnswerViewingTimeCanRun = false;

        public QuizTime()
        {
            InitializeComponent();
            AnswerButtons = new List<Button>();
            AddButtonsToList();

            UpdateGameInformation();

            ShowQuestionInformation();

            PlayerNoLabel.Text = PlayerCredentials.Instance.Player.Name;

            startTime = DateTime.Now;
        }

        private void ShowQuestionInformation()
        {


            QuestionTextField.Text = CurrentQuestion.Text;

            AnswerButton1.Text = CurrentQuestion.Answers[0].Text;
            AnswerButton2.Text = CurrentQuestion.Answers[1].Text;
            AnswerButton3.Text = CurrentQuestion.Answers[2].Text;
            AnswerButton4.Text = CurrentQuestion.Answers[3].Text;

            QuestionNoLabel.Text = CurrentRound.RoundNo.ToString();
        }

        private void UpdateGameInformation()
        {
            GameInstance.Instance.UpdateCurrentGame();
            CurrentGame = GameInstance.Instance.Game;
            CurrentRound = CurrentGame.Rounds.LastOrDefault();
            CurrentQuestion = CurrentRound.Question;

            EnableDisableButtons(true);

            foreach (Button aButton in AnswerButtons)
            {
                aButton.BackColor = Color.Transparent;
            }
        }

        private void AddButtonsToList()
        {
            AnswerButtons.Add(AnswerButton1);
            AnswerButtons.Add(AnswerButton2);
            AnswerButtons.Add(AnswerButton3);
            AnswerButtons.Add(AnswerButton4);
        }

        private void AnswerButton1_Click(object sender, EventArgs e)
        {
            EnableDisableButtons(false);
            PlayerAnswer.AnswerGiven = CurrentQuestion.Answers[0];
            Client.SubmitAnswer(CurrentRound, PlayerAnswer);
        }

        private void AnswerButton2_Click(object sender, EventArgs e)
        {
            EnableDisableButtons(false);
            PlayerAnswer.AnswerGiven = CurrentQuestion.Answers[1];
            Client.SubmitAnswer(CurrentRound, PlayerAnswer);
        }

        private void AnswerButton3_Click(object sender, EventArgs e)
        {
            EnableDisableButtons(false);
            PlayerAnswer.AnswerGiven = CurrentQuestion.Answers[2];
            Client.SubmitAnswer(CurrentRound, PlayerAnswer);
        }

        private void AnswerButton4_Click(object sender, EventArgs e)
        {
            EnableDisableButtons(false);
            PlayerAnswer.AnswerGiven = CurrentQuestion.Answers[3];
            Client.SubmitAnswer(CurrentRound, PlayerAnswer);
        }

        public void EnableDisableButtons(bool setting)
        {
            foreach (Button aButton in AnswerButtons)
            {
                aButton.Enabled = setting;
            }
        }

        public void CheckButton()
        {
            for (int i = 0; i < AnswerButtons.Count; i++)
            {
                bool correct = Client.ValidateAnswer(CurrentQuestion.Answers[i]);

                if (correct == true)
                {
                    AnswerButtons[i].BackColor = Color.Lime;
                }
                else
                {
                    AnswerButtons[i].BackColor = Color.Red;
                }
            }
        }

        //public void CheckAllButtons()
        //{
        //    CheckButton(AnswerButton1);
        //    CheckButton(AnswerButton2);
        //    CheckButton(AnswerButton3);
        //    CheckButton(AnswerButton4);
        //    DisableButtons();
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (TimerCountdownCanRun)
            {
                int elaspedSeconds = (int)(DateTime.Now - startTime).TotalSeconds;
                int remainingSeconds = TimerCountdown - elaspedSeconds;
                StatusLabel.Text = String.Format("Time left to answer question: {0}", remainingSeconds);
                bool playersAnswered = Client.CheckIfAllPlayersAnswered(CurrentGame, CurrentRound);
                if (remainingSeconds <= 0 || playersAnswered)
                {
                    EnableDisableButtons(false);
                    CheckButton();
                    timer1.Stop();
                    startTime = DateTime.Now;
                    TimerCountdownCanRun = false;
                    AnswerViewingTimeCanRun = true;
                    timer1.Start();
                }
            }

        }

        private void NextRoundCountdown(object sender, EventArgs e)
        {
            if (AnswerViewingTimeCanRun)
            {
                int elaspedSeconds = (int)(DateTime.Now - startTime).TotalSeconds;
                int remainingSeconds = AnswerViewingTime - elaspedSeconds;
                StatusLabel.Text = String.Format("Seconds left until next round: {0}", remainingSeconds);

                if (remainingSeconds <= 0)
                {
                    timer1.Stop();
                    Client.CreateRound(CurrentGame);

                    UpdateGameInformation();
                    ShowQuestionInformation();

                    startTime = DateTime.Now;
                    TimerCountdownCanRun = true;
                    AnswerViewingTimeCanRun = false;
                    timer1.Start();
                }
            }

        }

        private void QuizTime_Load(object sender, EventArgs e)
        {
            timer1.Interval = (1 * 500);
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Tick += new EventHandler(NextRoundCountdown);
            timer1.Start();
        }
    }
}
