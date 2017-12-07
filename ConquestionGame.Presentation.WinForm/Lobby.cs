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
    public partial class Lobby : Form
    {
        ConquestionServiceClient client;

        public Lobby(Game game, ConquestionServiceClient conquestionServiceClient)
        {
            InitializeComponent();
            client = conquestionServiceClient;
            Game gameEntity = client.ChooseGame(game.Name, true);
            GameInstance.Instance.Game = gameEntity;
            GameInstance.Instance.client = client;
            label1.Text = gameEntity.Name;
            label3.Text = gameEntity.QuestionSet.Title;
          

            listBox1.DataSource = gameEntity.Players;
            listBox1.DisplayMember = "Name";
            listBox1.ValueMember = "Name";

            Start_Game.Enabled = false;
            CheckIfLobbyHost();

        }

        public void refreshPlayerList()
        {
            if (GameInstance.Instance.Game != null)
            {
                Game gameEntity = client.ChooseGame(GameInstance.Instance.Game.Name, true);

                listBox1.DataSource = gameEntity.Players;
                listBox1.DisplayMember = "Name";
                listBox1.ValueMember = "Name";

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            refreshPlayerList();
            CheckIfLobbyHost();
        }

        private void Lobby_Load(object sender, EventArgs e)
        {
            timer1.Interval = (1 * 1000); // 5 secs
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Tick += new EventHandler(timer2_Tick);
            timer1.Start();
            label6.Text = PlayerCredentials.Instance.Player.Name;
        }

        private void Start_Game_Click(object sender, EventArgs e)
        {
            client.StartGame(GameInstance.Instance.Game);
            StartGameWindow();
        }

        public void StartGameWindow()
        {
            GameInstance.Instance.UpdateCurrentGame();
            timer1.Stop();
            this.Hide();

            (new QuizTime(client)).Show();

        }

        private void Exit_Lobby_Click(object sender, EventArgs e)
        {
            client.LeaveGame(GameInstance.Instance.Game);
            GameInstance.Instance.Game = null;
            this.Hide();
            (new JoinGame(client)).Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //Checks to see if the game has been started by the lobby host
            if (GameInstance.Instance.Game != null)
            {
                var gameEntity = client.ChooseGame(GameInstance.Instance.Game.Name, false);
                if (gameEntity.GameStatus == Game.GameStatusEnum.ongoing)
                {
                    StartGameWindow();
                }
            }
        }

        private void CheckIfLobbyHost()
        {
            if (GameInstance.Instance.Game != null)
            {
                var gameEntity = client.ChooseGame(GameInstance.Instance.Game.Name, true);
                if (PlayerCredentials.Instance.Player.Name.Equals(gameEntity.Players[0].Name))
                {
                    Start_Game.Enabled = true;
                }
                else
                {
                    Start_Game.Enabled = false;
                }
            }
        }

        private void Lobby_Closing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
