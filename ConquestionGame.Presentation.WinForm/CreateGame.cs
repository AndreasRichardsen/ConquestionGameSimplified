﻿using ConquestionGame.Presentation.WinForm.ConquestionServiceReference;
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
    public partial class CreateGame : Form
    {
        ConquestionServiceClient client;
        public CreateGame(ConquestionServiceClient conquestionServiceClient)
        {
            InitializeComponent();
            client = conquestionServiceClient;
 
            comboBox2.DataSource = client.RetrieveAllQuestionSets();
            comboBox2.DisplayMember = "Title";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) &&  comboBox2.SelectedItem != null)
            {
                QuestionSet questionSet = client.RetrieveQuestionSetByTitle(comboBox2.Text);

                client.CreateGame2(new Game { Name = textBox1.Text }, questionSet.Title, Int32.Parse(maskedTextBox1.Text));
                Game game = client.RetrieveGame(textBox1.Text, false); ;

                client.AddPlayer(game);

                this.Hide();
                (new Lobby(game, client)).Show();
            }
            else
            {
                MessageBox.Show("All fields must be filled!", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CreateGame_Load(object sender, EventArgs e)
        {
            label4.Text = PlayerCredentials.Instance.Player.Name;
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new JoinGame(client)).Show();
        }

        private void CreateGame_Closing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
