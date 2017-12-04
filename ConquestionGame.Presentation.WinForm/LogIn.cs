using ConquestionGame.Presentation.WinForm.AuthenticationServiceReference;
using ConquestionGame.Presentation.WinForm.ConquestionServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConquestionGame.Presentation.WinForm
{
    public partial class LogIn : Form
    {
        ConquestionServiceClient client = new ConquestionServiceClient();
        AuthenticationServiceClient AuthClient = new AuthenticationServiceClient();
        bool IsLoggedIn = false;

        public LogIn()
        {
            ServicePointManager.ServerCertificateValidationCallback = (obj, certificate, chain, errors) => true;
            InitializeComponent();
            textBox2.PasswordChar = '\u25CF';
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            IsLoggedIn = AuthClient.Login(textBox1.Text, textBox2.Text);
            if (IsLoggedIn)
            {
                client.ClientCredentials.UserName.UserName = textBox1.Text;
                client.ClientCredentials.UserName.Password = textBox2.Text;
                PlayerCredentials.Instance.Player = client.RetrievePlayer(textBox1.Text);
                this.Hide();
                (new JoinGame(client)).Show();
            }
           
            else
            {
                MessageBox.Show("Error logging in! User name or password was incorrect", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void exit_button_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Login_Closing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new RegisterPlayer()).Show();
        }
    }
}
