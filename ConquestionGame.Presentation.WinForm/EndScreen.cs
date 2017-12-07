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
    public partial class EndScreen : Form
    {
        ConquestionServiceClient Client;
        Game CurrentGame = GameInstance.Instance.Game;
        List<Label> LabelList = new List<Label>();
        public EndScreen(ConquestionServiceClient conquestionServiceClient)
        {
            Client = conquestionServiceClient;
            InitializeComponent();
            AddLabelsToList();
        }

        public void AddLabelsToList()
        {
            LabelList.Add(label1);
            LabelList.Add(label2);
            LabelList.Add(label3);
            LabelList.Add(label4);
            LabelList.Add(label5);
            LabelList.Add(label6);
            LabelList.Add(label7);
            LabelList.Add(label8);

        }

        private void EndScreen_Load(object sender, EventArgs e)
        {

            if (Client.DetermineGameWinner(CurrentGame) != null)
            {
                winner.Text = "The winner is: " + Client.DetermineGameWinner(CurrentGame).Name;

            }
            else
            {
                winner.Text = "You guys fucking suck!";
            }

            int i = 0;
            foreach (Player p in CurrentGame.Players)
            {
                LabelList[i].Text = p.Name;
                LabelList[i + 1].Text = string.Format("{0}", Client.DetermineNoOfCorrectAnswers(CurrentGame, p));
                i += 2;
            }

        }

        private void EndScreen_Closing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new JoinGame(Client)).Show();
            GameInstance.Instance.Game = null;
        }
    }
}
