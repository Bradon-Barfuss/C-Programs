using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using System.Collections.Generic;

namespace Assignment3
{
    public partial class Form1 : Form
    {
        #region Attributes
        int StudentCount; //How many students there are
        int AssignmentCount; //How many assignments there are
        List<string> StudentArray = new List<string>(); //Where students names are located
        List<List<int>> AssignmentArray = new List<List<int>>(); //Where assignments and assignment scores are located
        int FocusedStudent; //which student is currently being presented on the screen
        bool StudentsSet = false; //Checks if the bottom half of the program can do things depending if the user enter a valid count
        #endregion

        #region Methods

        #region Other Methods
        /// <summary>
        /// Starts the form
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            SetProgramDefaults();
        }

        /// <summary>
        /// Check if the input selected is inbetween selected boundiers
        /// </summary>
        /// <param name="text"></param>
        /// <param name="MaxInput"></param>
        /// <returns></returns>
        public bool ValidateInput(string text, int MaxInput)
        {
            int i;
            if (Int32.TryParse(text, out i))
            { //check if it is a interger
                if (i > 0 && i <= MaxInput) //if it is between 0 and max number
                {
                    return true;
                }
            }
            else { return false; }
            return false;
        }


        /// <summary>
        /// Set program to defaults
        /// </summary>
        public void SetProgramDefaults()
        {
            StudentCount = 0;
            AssignmentCount = 0;
            FocusedStudent = 0;
            StudentArray.Clear(); //Where students names are located
            AssignmentArray.Clear();
            StatsDisplayBox.Text = "";
            StudentsSet = false;
            StudentInfoLabel.Visible = false;
        }
        #endregion

        #region Counts Region
        /// <summary>
        /// Validates user entered correct students and assignment counts within bounds and updates the data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SumbitCountButton_Click(object sender, EventArgs e)
        {
            ResetErrorLabels();
            bool ValidInput = true;
            if (ValidateInput(NumOfStudentsTextBox.Text, 10) == false) //Check if the number of students is under or equal to 10
            {
                NumberOfStudentErrorLabel.Visible = true; //make error label visible
                ValidInput = false;
            }
            if (ValidateInput(NumOfAssignmentsTextBox.Text, 99) == false) //check if the number of assignments is under or equal to 99
            {
                NumOfAssignmentErrorLabel.Visible = true; //make error label visible
                ValidInput = false;
            }
            if (ValidInput == true)
            {
                StudentCount = Int32.Parse(NumOfStudentsTextBox.Text) - 1; //set Student Count Variable
                AssignmentCount = Int32.Parse(NumOfAssignmentsTextBox.Text) - 1; //Set Assignment count variable
                StudentsSet = true; //enables other parts of the program to work only when a vaild input is set
                SetUpStudentNameArray();
                SetUpStudentAssignmentArray();
                UpdateStudentText();
                SetAssignmentLabel();
                StudentInfoLabel.Visible = true;
                UpdateStatsDisplay();
            }
        }

        /// <summary>
        /// Reset the values of the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetButton_Click(object sender, EventArgs e)
        {
            SetProgramDefaults();
        }

        /// <summary>
        /// Reset the warning labels on the screen
        /// </summary>
        public void ResetErrorLabels()
        {
            NumberOfStudentErrorLabel.Visible = false;
            NumOfAssignmentErrorLabel.Visible = false;
        }
        #endregion

        #region Navigation Region
        /// <summary>
        /// Display the first Student
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoToFirstStudentButton_Click(object sender, EventArgs e)
        {
            if (StudentsSet)
            {
                FocusedStudent = 0;
                UpdateStudentText();

            }
        }

        /// <summary>
        /// Display the previous student
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoToPrevStudentButton_Click(object sender, EventArgs e)
        {
            if (StudentsSet && FocusedStudent > 0)
            {
                FocusedStudent--;
                UpdateStudentText();

            }
        }

        /// <summary>
        /// Display the next student
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoToNextStudentButton_Click(object sender, EventArgs e)
        {
            if (StudentsSet && (FocusedStudent < StudentCount))
            {
                FocusedStudent++;
                UpdateStudentText();

            }
        }

        /// <summary>
        /// Display the last student
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoToLastStudentButton_Click(object sender, EventArgs e)
        {
            if (StudentsSet)
            {
                FocusedStudent = StudentCount;
                UpdateStudentText();

            }
        }
        #endregion

        #region Student Info Region
        /// <summary>
        /// Update the label of the crurrently selected student
        /// </summary>
        public void UpdateStudentText()
        {
            StudentInfoLabel.Text = StudentArray.ElementAt(FocusedStudent);
        }

        /// <summary>
        /// Set the List for the default student names
        /// </summary>
        public void SetUpStudentNameArray()
        {
            for (int i = 0; i <= StudentCount; i++)
            {
                StudentArray.Add($"Student #{i + 1}");
            }
        }

        /// <summary>
        /// Sets up the Students assigment array by setting everything to 0
        /// </summary>
        public void SetUpStudentAssignmentArray()
        {
            for (int i = 0; i <= StudentCount; i++)
            {
                AssignmentArray.Add(new List<int>());
                for (int j = 0; j <= AssignmentCount; j++)
                {
                    AssignmentArray[i].Add(0);

                }
            }
        }

        /// <summary>
        /// Set the name for the Focused student based on user input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetNameButton_Click(object sender, EventArgs e)
        {
            if (StudentsSet) // when the amount of student and assignments are validly set
            {
                StudentArray[FocusedStudent] = SetStudentNameTextBox.Text;
                UpdateStudentText();
            }
        }

        /// <summary>
        /// Update the assigment label
        /// </summary>
        public void SetAssignmentLabel()
        {
            EnterAssignNumberLabel.Text = $"Enter Assignment Number (1-{AssignmentCount + 1})";
        }
        /// <summary>
        /// Set the Student Assigment scores when save button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveScoreBut_Click(object sender, EventArgs e)
        {
            bool valid = true;
            if (ValidateInput(SelectedAssignNumTxtBox.Text, AssignmentCount+1) == false)
            {
                valid = false;
            }
            if (ValidateInput(SetAssignScoreTxtBox.Text, 100) == false)
            {
                valid = false;
            }
            if (valid == true)
            {
                AssignmentArray[FocusedStudent][Int32.Parse(SelectedAssignNumTxtBox.Text) - 1] = Int32.Parse(SetAssignScoreTxtBox.Text);
            }
        }

        #endregion

        #region Score Section
        /// <summary>
        /// Update the stats display
        /// </summary>
        public void UpdateStatsDisplay()
        {
            double averageGrade = 0;
            StatsDisplayBox.Text = "Student\t\t "; //Display header
            for (int i = 0; i <= AssignmentCount; i++)
            {
                StatsDisplayBox.AppendText($"#{i + 1}\t"); //display header
            }
            StatsDisplayBox.AppendText($"AVG\t"); //display header
            StatsDisplayBox.AppendText($"GRADE\t\n"); //display header

            for (int i = 0; i <= StudentCount; i++)
            {
                StatsDisplayBox.AppendText(Environment.NewLine); //https://stackoverflow.com/questions/13318561/adding-new-line-of-data-to-textbox
                StatsDisplayBox.AppendText($"{StudentArray[i]}");
                StatsDisplayBox.AppendText("              ");
                for (int j = 0; j <= AssignmentCount; j++)
                {
                    averageGrade += AssignmentArray[i][j];//to get the average grade of that student
                    StatsDisplayBox.AppendText($"{AssignmentArray[i][j]}");//Display the grade for the student and assigment
                    StatsDisplayBox.AppendText("              ");//Spacing
                }
                StatsDisplayBox.AppendText($"{averageGrade / (AssignmentCount + 1)}"); //Display The Average Grade
                StatsDisplayBox.AppendText("              ");//Spacing
                StatsDisplayBox.AppendText($"{ReturnLetter(averageGrade / (AssignmentCount + 1))}"); //Display the letter Grade
                averageGrade = 0; //reset the average grade for the next student
            }
        }

        /// <summary>
        /// Return grade letter depending on the score
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        public string ReturnLetter(double score)
        {
            if (score >= 93 && score <= 100) { return "A"; }
            else if (score >= 90 && score < 93) { return "A-"; }
            else if (score >= 87 && score < 90) { return "B+"; }
            else if (score >= 83 && score < 87) { return "B"; }
            else if (score >= 80 && score < 83) { return "B-"; }
            else if (score >= 77 && score < 80) { return "C+"; }
            else if (score >= 73 && score < 77) { return "C"; }
            else if (score >= 70 && score < 73) { return "C-"; }
            else if (score >= 67 && score < 70) { return "D+"; }
            else if (score >= 63 && score < 67) { return "D"; }
            else if (score >= 60 && score < 63) { return "D-"; }
            else if (score < 60) { return "E"; }
            return "#";
        }

        /// <summary>
        /// Display the score by pressing this button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayScoreButton_Click(object sender, EventArgs e)
        {
            if (StudentsSet)
            {
                UpdateStatsDisplay();
            }
        }

        #endregion

        #endregion
    }
}
