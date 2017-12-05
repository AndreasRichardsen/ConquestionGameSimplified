using ConquestionGame.Presentation.WinForm.AuthenticationServiceReference;
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
    public partial class RegisterPlayer : Form
    {
        AuthenticationServiceReference.Player newPlayer = new AuthenticationServiceReference.Player();
        AuthenticationServiceClient AuthClient = new AuthenticationServiceClient();
        ConquestionServiceClient ConqClient = new ConquestionServiceClient();
        public RegisterPlayer()
        {
            InitializeComponent();
            PasswordTextbox.PasswordChar = '\u25CF';
            ConfirmPasswordTextbox.PasswordChar = '\u25CF';
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new LogIn()).Show();
        }

        private void RegisterPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            newPlayer.Name = UserNameTextBox.Text;
            string email = EmailTextBox.Text;
            string password = "";

            if (PasswordTextbox.Text.Equals(ConfirmPasswordTextbox.Text))
            {
                password = PasswordTextbox.Text;
            }

            try
            {
                AuthenticationServiceReference.Player player = AuthClient.RegisterPlayer(newPlayer, email, password);
                ConqClient.ClientCredentials.UserName.UserName = UserNameTextBox.Text;
                ConqClient.ClientCredentials.UserName.Password = PasswordTextbox.Text;

                PlayerCredentials.Instance.Player = ConqClient.RetrievePlayer(player.Name);
                this.Hide();
                (new JoinGame(ConqClient)).Show();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                MessageBox.Show("Error with registering a user: " + msg, "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
