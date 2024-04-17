namespace Assignment2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            GameInfoContainer = new GroupBox();
            NumberLostLabel = new Label();
            NumberWonLabel = new Label();
            NumberPlayedLabel = new Label();
            EnterUserGuessLabel = new Label();
            UserGuessTextBox = new TextBox();
            RollButton = new Button();
            ResetButton = new Button();
            TotalStatsGroupBox = new GroupBox();
            ErrorLabel = new Label();
            DiceImageBox = new PictureBox();
            GameInfoContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DiceImageBox).BeginInit();
            SuspendLayout();
            // 
            // GameInfoContainer
            // 
            GameInfoContainer.Controls.Add(NumberLostLabel);
            GameInfoContainer.Controls.Add(NumberWonLabel);
            GameInfoContainer.Controls.Add(NumberPlayedLabel);
            GameInfoContainer.Location = new Point(12, 12);
            GameInfoContainer.Name = "GameInfoContainer";
            GameInfoContainer.Size = new Size(431, 151);
            GameInfoContainer.TabIndex = 0;
            GameInfoContainer.TabStop = false;
            GameInfoContainer.Text = "Game Info";
            // 
            // NumberLostLabel
            // 
            NumberLostLabel.AutoSize = true;
            NumberLostLabel.Location = new Point(24, 112);
            NumberLostLabel.Name = "NumberLostLabel";
            NumberLostLabel.Size = new Size(50, 20);
            NumberLostLabel.TabIndex = 2;
            NumberLostLabel.Text = "label3";
            // 
            // NumberWonLabel
            // 
            NumberWonLabel.AutoSize = true;
            NumberWonLabel.Location = new Point(24, 75);
            NumberWonLabel.Name = "NumberWonLabel";
            NumberWonLabel.Size = new Size(50, 20);
            NumberWonLabel.TabIndex = 1;
            NumberWonLabel.Text = "label2";
            // 
            // NumberPlayedLabel
            // 
            NumberPlayedLabel.AutoSize = true;
            NumberPlayedLabel.Location = new Point(24, 35);
            NumberPlayedLabel.Name = "NumberPlayedLabel";
            NumberPlayedLabel.Size = new Size(179, 20);
            NumberPlayedLabel.TabIndex = 0;
            NumberPlayedLabel.Text = "Number of Times Played: ";
            // 
            // EnterUserGuessLabel
            // 
            EnterUserGuessLabel.AutoSize = true;
            EnterUserGuessLabel.Location = new Point(12, 189);
            EnterUserGuessLabel.Name = "EnterUserGuessLabel";
            EnterUserGuessLabel.Size = new Size(160, 20);
            EnterUserGuessLabel.TabIndex = 1;
            EnterUserGuessLabel.Text = "Enter your guess (1-6): ";
            // 
            // UserGuessTextBox
            // 
            UserGuessTextBox.BorderStyle = BorderStyle.FixedSingle;
            UserGuessTextBox.Location = new Point(178, 189);
            UserGuessTextBox.Name = "UserGuessTextBox";
            UserGuessTextBox.Size = new Size(30, 27);
            UserGuessTextBox.TabIndex = 2;
            // 
            // RollButton
            // 
            RollButton.Location = new Point(312, 189);
            RollButton.Name = "RollButton";
            RollButton.Size = new Size(94, 29);
            RollButton.TabIndex = 3;
            RollButton.Text = "Roll";
            RollButton.UseVisualStyleBackColor = true;
            RollButton.Click += RollButton_Click;
            // 
            // ResetButton
            // 
            ResetButton.Location = new Point(312, 251);
            ResetButton.Name = "ResetButton";
            ResetButton.Size = new Size(94, 29);
            ResetButton.TabIndex = 4;
            ResetButton.Text = "Reset";
            ResetButton.UseVisualStyleBackColor = true;
            ResetButton.Click += ResetButton_Click;
            // 
            // TotalStatsGroupBox
            // 
            TotalStatsGroupBox.Location = new Point(7, 355);
            TotalStatsGroupBox.Name = "TotalStatsGroupBox";
            TotalStatsGroupBox.Size = new Size(436, 210);
            TotalStatsGroupBox.TabIndex = 5;
            TotalStatsGroupBox.TabStop = false;
            TotalStatsGroupBox.Text = "Total Stats";
            // 
            // ErrorLabel
            // 
            ErrorLabel.AutoSize = true;
            ErrorLabel.Location = new Point(214, 189);
            ErrorLabel.Name = "ErrorLabel";
            ErrorLabel.Size = new Size(49, 20);
            ErrorLabel.TabIndex = 6;
            ErrorLabel.Text = "Error!!";
            ErrorLabel.Visible = false;
            // 
            // DiceImageBox
            // 
            DiceImageBox.Location = new Point(47, 229);
            DiceImageBox.Name = "DiceImageBox";
            DiceImageBox.Size = new Size(75, 75);
            DiceImageBox.TabIndex = 7;
            DiceImageBox.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(454, 577);
            Controls.Add(DiceImageBox);
            Controls.Add(ErrorLabel);
            Controls.Add(TotalStatsGroupBox);
            Controls.Add(ResetButton);
            Controls.Add(RollButton);
            Controls.Add(UserGuessTextBox);
            Controls.Add(EnterUserGuessLabel);
            Controls.Add(GameInfoContainer);
            Name = "Form1";
            Text = "Form1";
            GameInfoContainer.ResumeLayout(false);
            GameInfoContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DiceImageBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox GameInfoContainer;
        private Label EnterUserGuessLabel;
        private TextBox UserGuessTextBox;
        private Button RollButton;
        private Button ResetButton;
        private GroupBox TotalStatsGroupBox;
        private Label NumberLostLabel;
        private Label NumberWonLabel;
        private Label NumberPlayedLabel;
        private Label ErrorLabel;
        private PictureBox DiceImageBox;
    }
}
