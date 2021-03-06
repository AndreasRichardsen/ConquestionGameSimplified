﻿namespace ConquestionGame.Presentation.WinForm
{
    partial class QuizTime
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
            this.QuestionTextField = new System.Windows.Forms.TextBox();
            this.AnswerButton1 = new System.Windows.Forms.Button();
            this.AnswerButton2 = new System.Windows.Forms.Button();
            this.AnswerButton3 = new System.Windows.Forms.Button();
            this.AnswerButton4 = new System.Windows.Forms.Button();
            this.PlayerNoLabel = new System.Windows.Forms.Label();
            this.QuestionNoLabel = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // QuestionTextField
            // 
            this.QuestionTextField.Location = new System.Drawing.Point(23, 45);
            this.QuestionTextField.Margin = new System.Windows.Forms.Padding(2);
            this.QuestionTextField.Multiline = true;
            this.QuestionTextField.Name = "QuestionTextField";
            this.QuestionTextField.ReadOnly = true;
            this.QuestionTextField.Size = new System.Drawing.Size(527, 73);
            this.QuestionTextField.TabIndex = 0;
            // 
            // AnswerButton1
            // 
            this.AnswerButton1.Location = new System.Drawing.Point(23, 122);
            this.AnswerButton1.Margin = new System.Windows.Forms.Padding(2);
            this.AnswerButton1.Name = "AnswerButton1";
            this.AnswerButton1.Size = new System.Drawing.Size(526, 61);
            this.AnswerButton1.TabIndex = 1;
            this.AnswerButton1.Text = "button1";
            this.AnswerButton1.UseVisualStyleBackColor = true;
            this.AnswerButton1.Click += new System.EventHandler(this.AnswerButton1_Click);
            // 
            // AnswerButton2
            // 
            this.AnswerButton2.Location = new System.Drawing.Point(23, 188);
            this.AnswerButton2.Margin = new System.Windows.Forms.Padding(2);
            this.AnswerButton2.Name = "AnswerButton2";
            this.AnswerButton2.Size = new System.Drawing.Size(526, 61);
            this.AnswerButton2.TabIndex = 2;
            this.AnswerButton2.Text = "button2";
            this.AnswerButton2.UseVisualStyleBackColor = true;
            this.AnswerButton2.Click += new System.EventHandler(this.AnswerButton2_Click);
            // 
            // AnswerButton3
            // 
            this.AnswerButton3.Location = new System.Drawing.Point(23, 254);
            this.AnswerButton3.Margin = new System.Windows.Forms.Padding(2);
            this.AnswerButton3.Name = "AnswerButton3";
            this.AnswerButton3.Size = new System.Drawing.Size(526, 61);
            this.AnswerButton3.TabIndex = 3;
            this.AnswerButton3.Text = "button3";
            this.AnswerButton3.UseVisualStyleBackColor = true;
            this.AnswerButton3.Click += new System.EventHandler(this.AnswerButton3_Click);
            // 
            // AnswerButton4
            // 
            this.AnswerButton4.Location = new System.Drawing.Point(23, 319);
            this.AnswerButton4.Margin = new System.Windows.Forms.Padding(2);
            this.AnswerButton4.Name = "AnswerButton4";
            this.AnswerButton4.Size = new System.Drawing.Size(526, 61);
            this.AnswerButton4.TabIndex = 4;
            this.AnswerButton4.Text = "button4";
            this.AnswerButton4.UseVisualStyleBackColor = true;
            this.AnswerButton4.Click += new System.EventHandler(this.AnswerButton4_Click);
            // 
            // PlayerNoLabel
            // 
            this.PlayerNoLabel.AutoSize = true;
            this.PlayerNoLabel.Location = new System.Drawing.Point(498, 15);
            this.PlayerNoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PlayerNoLabel.Name = "PlayerNoLabel";
            this.PlayerNoLabel.Size = new System.Drawing.Size(51, 13);
            this.PlayerNoLabel.TabIndex = 5;
            this.PlayerNoLabel.Text = "Player no";
            // 
            // QuestionNoLabel
            // 
            this.QuestionNoLabel.AutoSize = true;
            this.QuestionNoLabel.Location = new System.Drawing.Point(21, 15);
            this.QuestionNoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.QuestionNoLabel.Name = "QuestionNoLabel";
            this.QuestionNoLabel.Size = new System.Drawing.Size(64, 13);
            this.QuestionNoLabel.TabIndex = 6;
            this.QuestionNoLabel.Text = "Question no";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(21, 391);
            this.StatusLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(82, 13);
            this.StatusLabel.TabIndex = 7;
            this.StatusLabel.Text = "Status message";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.QuestionCountdown);
            // 
            // QuizTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 421);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.QuestionNoLabel);
            this.Controls.Add(this.PlayerNoLabel);
            this.Controls.Add(this.AnswerButton4);
            this.Controls.Add(this.AnswerButton3);
            this.Controls.Add(this.AnswerButton2);
            this.Controls.Add(this.AnswerButton1);
            this.Controls.Add(this.QuestionTextField);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "QuizTime";
            this.Text = "QuizTime";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuizTime_Closing);
            this.Load += new System.EventHandler(this.QuizTime_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox QuestionTextField;
        private System.Windows.Forms.Button AnswerButton1;
        private System.Windows.Forms.Button AnswerButton2;
        private System.Windows.Forms.Button AnswerButton3;
        private System.Windows.Forms.Button AnswerButton4;
        private System.Windows.Forms.Label PlayerNoLabel;
        private System.Windows.Forms.Label QuestionNoLabel;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Timer timer1;
    }
}