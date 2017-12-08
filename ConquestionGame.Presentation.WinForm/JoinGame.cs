using ConquestionGame.Presentation.WinForm.ConquestionServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConquestionGame.Presentation.WinForm
{
    public partial class JoinGame : Form
    {
        private ConquestionServiceClient client;
        public JoinGame(ConquestionServiceClient ConquestionServiceClient)
        {
            InitializeComponent();
            client = ConquestionServiceClient;
            if (client.RetrieveActiveGames().Length != 0)
            {
                listBox1.DataSource = client.RetrieveActiveGames();
                listBox1.DisplayMember = "Name";
                listBox1.ValueMember = "Name";
            }
            else
            {
                JoinGameButton.Enabled = false;
                listBox1.DataSource = new List<string>{ "No Active Games Found" };
            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void JoinGame_Click(object sender, EventArgs e)
        {
            Game game = listBox1.SelectedItem as Game;

            Game game2 = client.RetrieveGame(game.Name, false);
            bool success = client.JoinGame(game2);

            if (success)
            {
                this.Hide();
                (new Lobby(game2, client)).Show();
            }
            else
            {
                MessageBox.Show("Unable to join game!", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void CreateGame_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new CreateGame(client)).Show();
        }

        private void JoinGame_Load(object sender, EventArgs e)
        {
            label1.Text = client.ClientCredentials.UserName.UserName;

            timer1.Interval = (1 * 1000); // 5 secs
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            PlayerCredentials.Instance.Player = null;
            this.Hide();
            (new LogIn()).Show();
        }

        private void refreshGameList()
        {
            if (client.RetrieveActiveGames().Length != 0)
            {
                JoinGameButton.Enabled = true;
                int currentSelected = listBox1.SelectedIndex;
                listBox1.DataSource = client.RetrieveActiveGames();
                listBox1.DisplayMember = "Name";
                listBox1.ValueMember = "Name";
                try
                {
                    listBox1.SelectedIndex = currentSelected;
                }
                catch (ArgumentOutOfRangeException)
                {
                    listBox1.SelectedIndex = 0;
                }
            }
            else
            {
                listBox1.DataSource = new List<string> { "No Active Games Found" };
                JoinGameButton.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            refreshGameList();
        }

        private void JoinGame_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void JoinGame_Closing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
