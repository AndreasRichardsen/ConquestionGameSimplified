namespace ConquestionGame.Presentation.WinForm
{
    partial class JoinGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.CreateNewGameButton = new System.Windows.Forms.Button();
            this.JoinGameButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.back_button = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(15, 101);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(303, 264);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // CreateNewGameButton
            // 
            this.CreateNewGameButton.Location = new System.Drawing.Point(425, 394);
            this.CreateNewGameButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CreateNewGameButton.Name = "CreateNewGameButton";
            this.CreateNewGameButton.Size = new System.Drawing.Size(117, 29);
            this.CreateNewGameButton.TabIndex = 2;
            this.CreateNewGameButton.Text = "Create New Game";
            this.CreateNewGameButton.UseVisualStyleBackColor = true;
            this.CreateNewGameButton.Click += new System.EventHandler(this.CreateGame_Click);
            // 
            // JoinGameButton
            // 
            this.JoinGameButton.Location = new System.Drawing.Point(460, 101);
            this.JoinGameButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.JoinGameButton.Name = "JoinGameButton";
            this.JoinGameButton.Size = new System.Drawing.Size(82, 21);
            this.JoinGameButton.TabIndex = 4;
            this.JoinGameButton.Text = "Join Game";
            this.JoinGameButton.UseVisualStyleBackColor = true;
            this.JoinGameButton.Click += new System.EventHandler(this.JoinGame_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(469, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // back_button
            // 
            this.back_button.Location = new System.Drawing.Point(15, 25);
            this.back_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(72, 21);
            this.back_button.TabIndex = 6;
            this.back_button.Text = "< Back";
            this.back_button.UseVisualStyleBackColor = true;
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // JoinGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 443);
            this.Controls.Add(this.back_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.JoinGameButton);
            this.Controls.Add(this.CreateNewGameButton);
            this.Controls.Add(this.listBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "JoinGame";
            this.Text = "JoinGame";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JoinGame_Closing);
            this.Load += new System.EventHandler(this.JoinGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button CreateNewGameButton;
        private System.Windows.Forms.Button JoinGameButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button back_button;
        private System.Windows.Forms.Timer timer1;
    }
}

