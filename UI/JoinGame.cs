using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.ConquestionServiceReference;

namespace UI
{
    public partial class JoinGame : Form
    {
        public ConquestionServiceClient client = new ConquestionServiceClient();
        public JoinGame()
        {
            InitializeComponent();
            if (client.ActiveGames().Length != 0)
            {
                listBox1.DataSource = client.ActiveGames();
                listBox1.DisplayMember = "Name";
                listBox1.ValueMember = "Name";
            }
            else
            {
                MessageBox.Show("No active games found!", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void JoinGame_Click(object sender, EventArgs e)
        {
            Game game = listBox1.SelectedItem as Game;
            Game game2 = client.ChooseGame(game.Name, false);
            //label1.Text = CurrentPlayer.Name;
            bool success = client.JoinGame(game2, PlayerCredentials.Instance.Player);
            if (success)
            {
                this.Hide();
                (new Lobby(game2)).Show();
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
            (new CreateGame()).Show();
        }

        private void JoinGame_Load(object sender, EventArgs e)
        {
            label1.Text = PlayerCredentials.Instance.Player.Name;

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
            if (client.ActiveGames().Length != 0)
            {
                listBox1.DataSource = client.ActiveGames();
                listBox1.DisplayMember = "Name";
                listBox1.ValueMember = "Name";
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
