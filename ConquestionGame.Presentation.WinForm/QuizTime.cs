using ConquestionGame.Presentation.WinForm.ConquestionServiceReference;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;


namespace ConquestionGame.Presentation.WinForm
{
    public partial class QuizTime : Form
    {
        ConquestionServiceClient Client;

        Game CurrentGame = null;
        Question CurrentQuestion = null;
        Round CurrentRound = null;
        PlayerAnswer PlayerAnswer = new PlayerAnswer { Player = PlayerCredentials.Instance.Player };

        List<Button> AnswerButtons;

        DateTime startTime;
        private int QuestionCountdownTimer = 30;
        bool QuestionCountdownCanRun = true;
        private int NextRoundCoutdownTimer = 5;
        bool NextRoundCountdownCanRun = false;

        public QuizTime(ConquestionServiceClient conquestionServiceClient)
        {
            InitializeComponent();
            Client = conquestionServiceClient;
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

            QuestionNoLabel.Text = CurrentGame.NoOfRounds.ToString() + "/" + CurrentRound.RoundNo.ToString();
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

        private void QuestionCountdown(object sender, EventArgs e)
        {
            if (QuestionCountdownCanRun)
            {
                int elaspedSeconds = (int)(DateTime.Now - startTime).TotalSeconds;
                int remainingSeconds = QuestionCountdownTimer - elaspedSeconds;
                StatusLabel.Text = String.Format("Time left to answer question: {0}", remainingSeconds);
                bool playersAnswered = Client.CheckIfAllPlayersAnswered(CurrentGame, CurrentRound);
                if (remainingSeconds <= 0 || playersAnswered)
                {
                    Client.CreateRound(CurrentGame); 
                    EnableDisableButtons(false);
                    CheckButton();
                    timer1.Stop();
                    startTime = DateTime.Now;
                    QuestionCountdownCanRun = false;
                    NextRoundCountdownCanRun = true;
                    timer1.Start();
                }
            }

        }

        private void NextRoundCountdown(object sender, EventArgs e)
        {
            if (NextRoundCountdownCanRun)
            {
                int elaspedSeconds = (int)(DateTime.Now - startTime).TotalSeconds;
                int remainingSeconds = NextRoundCoutdownTimer - elaspedSeconds;
                StatusLabel.Text = String.Format("Seconds left until next round: {0}", remainingSeconds);
                Player roundWinner = Client.RetrieveRoundWinner(CurrentRound);
                if (roundWinner != null)
                {
                    StatusLabel.Text += String.Format("  Round Winner: {0}!", roundWinner.Name);
                }
                else
                {
                    StatusLabel.Text += String.Format("  No winner this time!");
                }

                if (remainingSeconds <= 0)
                {
                    timer1.Stop();
                    UpdateGameInformation();
                    ShowQuestionInformation();
                    startTime = DateTime.Now;
                    QuestionCountdownCanRun = true;
                    NextRoundCountdownCanRun = false;
                    timer1.Start();
                }
            }

        }

        private void QuizTime_Load(object sender, EventArgs e)
        {
            timer1.Interval = (1 * 500);
            timer1.Tick += new EventHandler(QuestionCountdown);
            timer1.Tick += new EventHandler(NextRoundCountdown);
            timer1.Tick += new EventHandler(CheckEndCondition);
            timer1.Start();
        }

        private void QuizTime_Closing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void CheckEndCondition(object sender, EventArgs e)
        {
            if (Client.CheckIfGameIsFinished(CurrentGame) && !NextRoundCountdownCanRun)
            {
                
                timer1.Stop();
                QuestionCountdownCanRun = false;
                this.Hide();
                (new EndScreen(Client)).Show();
            }
        }
    }
}
