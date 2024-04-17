namespace Assignment1
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
            NameTextBox = new TextBox();
            NameButton = new Button();
            VirusTextBox = new TextBox();
            TemperatureTextBox = new TextBox();
            VirusButton = new Button();
            TemperatureButton = new Button();
            NameLabel = new Label();
            VirusLabel = new Label();
            TemperatureLabel = new Label();
            SuspendLayout();
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(31, 21);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(625, 27);
            NameTextBox.TabIndex = 0;
            // 
            // NameButton
            // 
            NameButton.Location = new Point(31, 54);
            NameButton.Name = "NameButton";
            NameButton.Size = new Size(196, 29);
            NameButton.TabIndex = 1;
            NameButton.Text = "See Your Name";
            NameButton.UseVisualStyleBackColor = true;
            NameButton.Click += NameButton_Click;
            // 
            // VirusTextBox
            // 
            VirusTextBox.Location = new Point(31, 91);
            VirusTextBox.Name = "VirusTextBox";
            VirusTextBox.Size = new Size(314, 27);
            VirusTextBox.TabIndex = 2;
            // 
            // TemperatureTextBox
            // 
            TemperatureTextBox.Location = new Point(31, 169);
            TemperatureTextBox.Name = "TemperatureTextBox";
            TemperatureTextBox.Size = new Size(314, 27);
            TemperatureTextBox.TabIndex = 3;
            // 
            // VirusButton
            // 
            VirusButton.Location = new Point(31, 131);
            VirusButton.Name = "VirusButton";
            VirusButton.Size = new Size(196, 29);
            VirusButton.TabIndex = 4;
            VirusButton.Text = "Virus! -> Click Here <-";
            VirusButton.UseVisualStyleBackColor = true;
            VirusButton.Click += VirusButton_Click;
            // 
            // TemperatureButton
            // 
            TemperatureButton.Location = new Point(31, 202);
            TemperatureButton.Name = "TemperatureButton";
            TemperatureButton.Size = new Size(196, 29);
            TemperatureButton.TabIndex = 5;
            TemperatureButton.Text = "See your Temperature";
            TemperatureButton.UseVisualStyleBackColor = true;
            TemperatureButton.Click += TemperatureButton_Click;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(238, 58);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(397, 20);
            NameLabel.TabIndex = 6;
            NameLabel.Text = "See your name when you click the \"See Your Name\" Button";
            NameLabel.Click += SeeNameLabel_Click;
            // 
            // VirusLabel
            // 
            VirusLabel.AutoSize = true;
            VirusLabel.Location = new Point(238, 135);
            VirusLabel.Name = "VirusLabel";
            VirusLabel.Size = new Size(374, 20);
            VirusLabel.TabIndex = 7;
            VirusLabel.Text = "You can get a virus if you click this (not really tbh, haha)";
            // 
            // TemperatureLabel
            // 
            TemperatureLabel.AutoSize = true;
            TemperatureLabel.Location = new Point(244, 208);
            TemperatureLabel.Name = "TemperatureLabel";
            TemperatureLabel.Size = new Size(439, 20);
            TemperatureLabel.TabIndex = 8;
            TemperatureLabel.Text = "It is COLD outside, see how cold it is by inserting your tempature!";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(714, 243);
            Controls.Add(TemperatureLabel);
            Controls.Add(VirusLabel);
            Controls.Add(NameLabel);
            Controls.Add(TemperatureButton);
            Controls.Add(VirusButton);
            Controls.Add(TemperatureTextBox);
            Controls.Add(VirusTextBox);
            Controls.Add(NameButton);
            Controls.Add(NameTextBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox NameTextBox;
        private Button NameButton;
        private TextBox VirusTextBox;
        private TextBox TemperatureTextBox;
        private Button VirusButton;
        private Button TemperatureButton;
        private Label NameLabel;
        private Label VirusLabel;
        private Label TemperatureLabel;
    }
}
