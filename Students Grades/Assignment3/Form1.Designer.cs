namespace Assignment3
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
            CountsGroupBox = new GroupBox();
            NumberOfStudentErrorLabel = new Label();
            NumOfAssignmentErrorLabel = new Label();
            SumbitCountButton = new Button();
            NumOfAssignmentsTextBox = new TextBox();
            NumOfStudentsTextBox = new TextBox();
            NumOfAssignmentsLabel = new Label();
            NumOfStudentsLabel = new Label();
            ResetButton = new Button();
            NavigateGroupBox = new GroupBox();
            GoToLastStudentButton = new Button();
            GoToNextStudentButton = new Button();
            GoToPrevStudentButton = new Button();
            GoToFirstStudentButton = new Button();
            StudentInfoGroupBox = new GroupBox();
            SetNameButton = new Button();
            SetStudentNameTextBox = new TextBox();
            StudentInfoLabel = new Label();
            AssignmentInfoGroupBox = new GroupBox();
            SaveScoreBut = new Button();
            SetAssignScoreTxtBox = new TextBox();
            SelectedAssignNumTxtBox = new TextBox();
            AssignScoreLabel = new Label();
            EnterAssignNumberLabel = new Label();
            StatsDisplayBox = new TextBox();
            DisplayScoreButton = new Button();
            CountsGroupBox.SuspendLayout();
            NavigateGroupBox.SuspendLayout();
            StudentInfoGroupBox.SuspendLayout();
            AssignmentInfoGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // CountsGroupBox
            // 
            CountsGroupBox.Controls.Add(NumberOfStudentErrorLabel);
            CountsGroupBox.Controls.Add(NumOfAssignmentErrorLabel);
            CountsGroupBox.Controls.Add(SumbitCountButton);
            CountsGroupBox.Controls.Add(NumOfAssignmentsTextBox);
            CountsGroupBox.Controls.Add(NumOfStudentsTextBox);
            CountsGroupBox.Controls.Add(NumOfAssignmentsLabel);
            CountsGroupBox.Controls.Add(NumOfStudentsLabel);
            CountsGroupBox.Location = new Point(12, 22);
            CountsGroupBox.Name = "CountsGroupBox";
            CountsGroupBox.Size = new Size(562, 125);
            CountsGroupBox.TabIndex = 0;
            CountsGroupBox.TabStop = false;
            CountsGroupBox.Text = "Count";
            // 
            // NumberOfStudentErrorLabel
            // 
            NumberOfStudentErrorLabel.AutoSize = true;
            NumberOfStudentErrorLabel.Location = new Point(333, 35);
            NumberOfStudentErrorLabel.Name = "NumberOfStudentErrorLabel";
            NumberOfStudentErrorLabel.Size = new Size(77, 20);
            NumberOfStudentErrorLabel.TabIndex = 7;
            NumberOfStudentErrorLabel.Text = "Input 1-10";
            NumberOfStudentErrorLabel.Visible = false;
            // 
            // NumOfAssignmentErrorLabel
            // 
            NumOfAssignmentErrorLabel.AutoSize = true;
            NumOfAssignmentErrorLabel.Location = new Point(329, 75);
            NumOfAssignmentErrorLabel.Name = "NumOfAssignmentErrorLabel";
            NumOfAssignmentErrorLabel.Size = new Size(77, 20);
            NumOfAssignmentErrorLabel.TabIndex = 6;
            NumOfAssignmentErrorLabel.Text = "Input 1-99";
            NumOfAssignmentErrorLabel.Visible = false;
            // 
            // SumbitCountButton
            // 
            SumbitCountButton.Location = new Point(435, 47);
            SumbitCountButton.Name = "SumbitCountButton";
            SumbitCountButton.Size = new Size(94, 29);
            SumbitCountButton.TabIndex = 4;
            SumbitCountButton.Text = "Submit Count";
            SumbitCountButton.UseVisualStyleBackColor = true;
            SumbitCountButton.Click += SumbitCountButton_Click;
            // 
            // NumOfAssignmentsTextBox
            // 
            NumOfAssignmentsTextBox.BorderStyle = BorderStyle.FixedSingle;
            NumOfAssignmentsTextBox.Location = new Point(193, 74);
            NumOfAssignmentsTextBox.Name = "NumOfAssignmentsTextBox";
            NumOfAssignmentsTextBox.Size = new Size(125, 27);
            NumOfAssignmentsTextBox.TabIndex = 3;
            // 
            // NumOfStudentsTextBox
            // 
            NumOfStudentsTextBox.BorderStyle = BorderStyle.FixedSingle;
            NumOfStudentsTextBox.Location = new Point(193, 33);
            NumOfStudentsTextBox.Name = "NumOfStudentsTextBox";
            NumOfStudentsTextBox.Size = new Size(125, 27);
            NumOfStudentsTextBox.TabIndex = 2;
            // 
            // NumOfAssignmentsLabel
            // 
            NumOfAssignmentsLabel.AutoSize = true;
            NumOfAssignmentsLabel.Location = new Point(11, 77);
            NumOfAssignmentsLabel.Name = "NumOfAssignmentsLabel";
            NumOfAssignmentsLabel.Size = new Size(175, 20);
            NumOfAssignmentsLabel.TabIndex = 1;
            NumOfAssignmentsLabel.Text = "Number of Assignments: ";
            // 
            // NumOfStudentsLabel
            // 
            NumOfStudentsLabel.AutoSize = true;
            NumOfStudentsLabel.Location = new Point(35, 36);
            NumOfStudentsLabel.Name = "NumOfStudentsLabel";
            NumOfStudentsLabel.Size = new Size(149, 20);
            NumOfStudentsLabel.TabIndex = 0;
            NumOfStudentsLabel.Text = "Number of Students: ";
            // 
            // ResetButton
            // 
            ResetButton.Location = new Point(614, 55);
            ResetButton.Name = "ResetButton";
            ResetButton.Size = new Size(94, 57);
            ResetButton.TabIndex = 1;
            ResetButton.Text = "Reset All";
            ResetButton.UseVisualStyleBackColor = true;
            ResetButton.Click += ResetButton_Click;
            // 
            // NavigateGroupBox
            // 
            NavigateGroupBox.Controls.Add(GoToLastStudentButton);
            NavigateGroupBox.Controls.Add(GoToNextStudentButton);
            NavigateGroupBox.Controls.Add(GoToPrevStudentButton);
            NavigateGroupBox.Controls.Add(GoToFirstStudentButton);
            NavigateGroupBox.Location = new Point(18, 178);
            NavigateGroupBox.Name = "NavigateGroupBox";
            NavigateGroupBox.Size = new Size(690, 87);
            NavigateGroupBox.TabIndex = 2;
            NavigateGroupBox.TabStop = false;
            NavigateGroupBox.Text = "Navigate";
            // 
            // GoToLastStudentButton
            // 
            GoToLastStudentButton.Location = new Point(532, 34);
            GoToLastStudentButton.Name = "GoToLastStudentButton";
            GoToLastStudentButton.Size = new Size(139, 29);
            GoToLastStudentButton.TabIndex = 3;
            GoToLastStudentButton.Text = "Last Student >>";
            GoToLastStudentButton.UseVisualStyleBackColor = true;
            GoToLastStudentButton.Click += GoToLastStudentButton_Click;
            // 
            // GoToNextStudentButton
            // 
            GoToNextStudentButton.Location = new Point(366, 34);
            GoToNextStudentButton.Name = "GoToNextStudentButton";
            GoToNextStudentButton.Size = new Size(150, 29);
            GoToNextStudentButton.TabIndex = 2;
            GoToNextStudentButton.Text = "Next Student >";
            GoToNextStudentButton.UseVisualStyleBackColor = true;
            GoToNextStudentButton.Click += GoToNextStudentButton_Click;
            // 
            // GoToPrevStudentButton
            // 
            GoToPrevStudentButton.Location = new Point(186, 34);
            GoToPrevStudentButton.Name = "GoToPrevStudentButton";
            GoToPrevStudentButton.Size = new Size(150, 29);
            GoToPrevStudentButton.TabIndex = 1;
            GoToPrevStudentButton.Text = "< Prev Student";
            GoToPrevStudentButton.UseVisualStyleBackColor = true;
            GoToPrevStudentButton.Click += GoToPrevStudentButton_Click;
            // 
            // GoToFirstStudentButton
            // 
            GoToFirstStudentButton.Location = new Point(20, 34);
            GoToFirstStudentButton.Name = "GoToFirstStudentButton";
            GoToFirstStudentButton.Size = new Size(150, 29);
            GoToFirstStudentButton.TabIndex = 0;
            GoToFirstStudentButton.Text = "<< First Student";
            GoToFirstStudentButton.UseVisualStyleBackColor = true;
            GoToFirstStudentButton.Click += GoToFirstStudentButton_Click;
            // 
            // StudentInfoGroupBox
            // 
            StudentInfoGroupBox.Controls.Add(SetNameButton);
            StudentInfoGroupBox.Controls.Add(SetStudentNameTextBox);
            StudentInfoGroupBox.Controls.Add(StudentInfoLabel);
            StudentInfoGroupBox.Location = new Point(22, 276);
            StudentInfoGroupBox.Name = "StudentInfoGroupBox";
            StudentInfoGroupBox.Size = new Size(612, 84);
            StudentInfoGroupBox.TabIndex = 3;
            StudentInfoGroupBox.TabStop = false;
            StudentInfoGroupBox.Text = "Student Info";
            // 
            // SetNameButton
            // 
            SetNameButton.Location = new Point(480, 34);
            SetNameButton.Name = "SetNameButton";
            SetNameButton.Size = new Size(94, 29);
            SetNameButton.TabIndex = 2;
            SetNameButton.Text = "Set Name";
            SetNameButton.UseVisualStyleBackColor = true;
            SetNameButton.Click += SetNameButton_Click;
            // 
            // SetStudentNameTextBox
            // 
            SetStudentNameTextBox.Location = new Point(146, 36);
            SetStudentNameTextBox.Name = "SetStudentNameTextBox";
            SetStudentNameTextBox.Size = new Size(272, 27);
            SetStudentNameTextBox.TabIndex = 1;
            // 
            // StudentInfoLabel
            // 
            StudentInfoLabel.AutoSize = true;
            StudentInfoLabel.Location = new Point(22, 39);
            StudentInfoLabel.Name = "StudentInfoLabel";
            StudentInfoLabel.Size = new Size(73, 20);
            StudentInfoLabel.TabIndex = 0;
            StudentInfoLabel.Text = "Student #";
            // 
            // AssignmentInfoGroupBox
            // 
            AssignmentInfoGroupBox.Controls.Add(SaveScoreBut);
            AssignmentInfoGroupBox.Controls.Add(SetAssignScoreTxtBox);
            AssignmentInfoGroupBox.Controls.Add(SelectedAssignNumTxtBox);
            AssignmentInfoGroupBox.Controls.Add(AssignScoreLabel);
            AssignmentInfoGroupBox.Controls.Add(EnterAssignNumberLabel);
            AssignmentInfoGroupBox.Location = new Point(25, 391);
            AssignmentInfoGroupBox.Name = "AssignmentInfoGroupBox";
            AssignmentInfoGroupBox.Size = new Size(609, 105);
            AssignmentInfoGroupBox.TabIndex = 4;
            AssignmentInfoGroupBox.TabStop = false;
            AssignmentInfoGroupBox.Text = "Assignment Info";
            // 
            // SaveScoreBut
            // 
            SaveScoreBut.Location = new Point(491, 41);
            SaveScoreBut.Name = "SaveScoreBut";
            SaveScoreBut.Size = new Size(94, 29);
            SaveScoreBut.TabIndex = 4;
            SaveScoreBut.Text = "Save Score";
            SaveScoreBut.UseVisualStyleBackColor = true;
            SaveScoreBut.Click += SaveScoreBut_Click;
            // 
            // SetAssignScoreTxtBox
            // 
            SetAssignScoreTxtBox.Location = new Point(249, 63);
            SetAssignScoreTxtBox.Name = "SetAssignScoreTxtBox";
            SetAssignScoreTxtBox.Size = new Size(125, 27);
            SetAssignScoreTxtBox.TabIndex = 3;
            // 
            // SelectedAssignNumTxtBox
            // 
            SelectedAssignNumTxtBox.Location = new Point(250, 28);
            SelectedAssignNumTxtBox.Name = "SelectedAssignNumTxtBox";
            SelectedAssignNumTxtBox.Size = new Size(125, 27);
            SelectedAssignNumTxtBox.TabIndex = 2;
            // 
            // AssignScoreLabel
            // 
            AssignScoreLabel.AutoSize = true;
            AssignScoreLabel.Location = new Point(71, 64);
            AssignScoreLabel.Name = "AssignScoreLabel";
            AssignScoreLabel.Size = new Size(134, 20);
            AssignScoreLabel.TabIndex = 1;
            AssignScoreLabel.Text = "Assignment Score: ";
            // 
            // EnterAssignNumberLabel
            // 
            EnterAssignNumberLabel.AutoSize = true;
            EnterAssignNumberLabel.Location = new Point(19, 33);
            EnterAssignNumberLabel.Name = "EnterAssignNumberLabel";
            EnterAssignNumberLabel.Size = new Size(182, 20);
            EnterAssignNumberLabel.TabIndex = 0;
            EnterAssignNumberLabel.Text = "Enter Assignment Number";
            // 
            // StatsDisplayBox
            // 
            StatsDisplayBox.AcceptsReturn = true;
            StatsDisplayBox.AcceptsTab = true;
            StatsDisplayBox.Location = new Point(23, 561);
            StatsDisplayBox.Multiline = true;
            StatsDisplayBox.Name = "StatsDisplayBox";
            StatsDisplayBox.ScrollBars = ScrollBars.Both;
            StatsDisplayBox.Size = new Size(685, 166);
            StatsDisplayBox.TabIndex = 5;
            StatsDisplayBox.WordWrap = false;
            // 
            // DisplayScoreButton
            // 
            DisplayScoreButton.Location = new Point(269, 518);
            DisplayScoreButton.Name = "DisplayScoreButton";
            DisplayScoreButton.Size = new Size(171, 29);
            DisplayScoreButton.TabIndex = 6;
            DisplayScoreButton.Text = "Display Scores";
            DisplayScoreButton.UseVisualStyleBackColor = true;
            DisplayScoreButton.Click += DisplayScoreButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(741, 737);
            Controls.Add(DisplayScoreButton);
            Controls.Add(StatsDisplayBox);
            Controls.Add(AssignmentInfoGroupBox);
            Controls.Add(StudentInfoGroupBox);
            Controls.Add(NavigateGroupBox);
            Controls.Add(ResetButton);
            Controls.Add(CountsGroupBox);
            Name = "Form1";
            Text = "Form1";
            CountsGroupBox.ResumeLayout(false);
            CountsGroupBox.PerformLayout();
            NavigateGroupBox.ResumeLayout(false);
            StudentInfoGroupBox.ResumeLayout(false);
            StudentInfoGroupBox.PerformLayout();
            AssignmentInfoGroupBox.ResumeLayout(false);
            AssignmentInfoGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox CountsGroupBox;
        private Button SumbitCountButton;
        private TextBox NumOfAssignmentsTextBox;
        private TextBox NumOfStudentsTextBox;
        private Label NumOfAssignmentsLabel;
        private Label NumOfStudentsLabel;
        private Label NumOfAssignmentErrorLabel;
        private Label NumOfStudentErrorLabel;
        private Label NumberOfStudentErrorLabel;
        private Button ResetButton;
        private GroupBox NavigateGroupBox;
        private Button GoToFirstStudentButton;
        private Button GoToPrevStudentButton;
        private Button GoToNextStudentButton;
        private Button GoToLastStudentButton;
        private GroupBox StudentInfoGroupBox;
        private Label StudentInfoLabel;
        private TextBox SetStudentNameTextBox;
        private Button SetNameButton;
        private GroupBox AssignmentInfoGroupBox;
        private Label EnterAssignNumberLabel;
        private Button SaveScoreBut;
        private TextBox SetAssignScoreTxtBox;
        private TextBox SelectedAssignNumTxtBox;
        private Label AssignScoreLabel;
        private TextBox StatsDisplayBox;
        private Button DisplayScoreButton;
    }
}
