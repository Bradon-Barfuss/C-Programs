using System.ComponentModel.DataAnnotations;

namespace Assignment2
{
    public partial class Form1 : Form
    {
        #region Attributes
        /// <summary>
        /// Number of guess that the user guessed correctly.
        /// </summary>
        private int GamesWon;

        /// <summary>
        /// Number of guess that the user gussed incorrectly.
        /// </summary>
        private int GamesLost;

        /// <summary>
        /// Total number of guess that the user has done.
        /// </summary>
        private int GamesTotal;

        /// <summary>
        /// Total number of rolls;
        /// </summary>
        private int TotalRolls;

        /// <summary>
        /// Number for the Curret Random Number
        /// </summary>
        private int RandomNumber;

        #endregion

        #region Objects
        dice Dice1;
        dice Dice2;
        dice Dice3;
        dice Dice4;
        dice Dice5;
        dice Dice6;

        #endregion

        #region Methods
        public Form1()
        {
            InitializeComponent();
            Dice1 = new dice(1);
            Dice2 = new dice(2);
            Dice3 = new dice(3);
            Dice4 = new dice(4);
            Dice5 = new dice(5);
            Dice6 = new dice(6);
            SetGameDefaults();
        }


        /// <summary>
        /// Set the game to Default Values
        /// </summary>
        private void SetGameDefaults()
        {
            GamesWon = 0;
            GamesLost = 0;
            TotalRolls = 0;
            GamesTotal = GamesWon + GamesLost;
            ResetAllDice();
            UpdateTotalScoreContainer();
            UpdateTotalStatsBox();
        }

        /// <summary>
        /// Reset All the Dice Values
        /// </summary>
        private void ResetAllDice()
        {
            Dice1.reset();
            Dice2.reset();
            Dice3.reset();
            Dice4.reset();
            Dice5.reset();
            Dice6.reset();
        }

        /// <summary>
        /// Update the Dice Images on screen
        /// </summary>
        /// <param name="diceface"></param>
        private void UpdateImages(int diceface)
        {
            DiceImageBox.SizeMode = PictureBoxSizeMode.StretchImage;

            for (int i = 0; i < 3; i++)
            {

                DiceImageBox.Image = Image.FromFile("die" + RandomNumberGenerator().ToString() + ".gif");
                DiceImageBox.Refresh();
                Thread.Sleep(300);
            }
            DiceImageBox.Image = Image.FromFile("die" + diceface.ToString() + ".gif");
        }
        /// <summary>
        /// When the Roll button is clicked, it will check if user entered valid information. Generate a random number. And display the resulting changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RollButton_Click(object sender, EventArgs e)
        {
            if (!ValidateGuess())
            {
                ErrorLabel.Visible = true;

            }
            else
            {
                ErrorLabel.Visible = false;
                RandomNumber = RandomNumberGenerator();
                UpdateImages(RandomNumber);
                RolledDiceUpdate();
                GuessedDiceUpdate();
                CheckGuessIsCorrect();
                GamesTotal = GamesLost + GamesWon;
                UpdateTotalStatsBox();
                UpdateTotalScoreContainer();
                //Change Image
            }
        }

        /// <summary>
        /// Get the percentage of how many times a dice been rolled compared to the total rolls of the current game
        /// </summary>
        /// <param name="DiceFace"></param>
        /// <returns></returns>
        private double GetDiceRolledPercentage(int DiceFace)
        {
            if (TotalRolls == 0)
            {
                return 0.00;
            }

            switch (DiceFace)
            {
                case 1:
                    return Convert.ToDouble(Dice1.GetDiceRolledNum()) / Convert.ToDouble(TotalRolls);
                case 2:
                    return Convert.ToDouble(Dice2.GetDiceRolledNum()) / Convert.ToDouble(TotalRolls);
                case 3:
                    return Convert.ToDouble(Dice3.GetDiceRolledNum()) / Convert.ToDouble(TotalRolls);
                case 4:
                    return Convert.ToDouble(Dice4.GetDiceRolledNum()) / Convert.ToDouble(TotalRolls);
                case 5:
                    return Convert.ToDouble(Dice5.GetDiceRolledNum()) / Convert.ToDouble(TotalRolls);
                case 6:
                    return Convert.ToDouble(Dice6.GetDiceRolledNum()) / Convert.ToDouble(TotalRolls);
            }
            return 0;

        }

        /// <summary>
        /// Display the Total Stats Box
        /// </summary>
        private void UpdateTotalStatsBox()
        {
            TotalStatsGroupBox.Text = 
                $"Face   Fequency   Percentage    Number of Times Guessed\n" +
                $" 1              {Dice1.GetDiceRolledNum()}               {GetDiceRolledPercentage(1).ToString("P")}                       {Dice1.GetDiceGuessedNum()}\n" +
                $" 2              {Dice2.GetDiceRolledNum()}               {GetDiceRolledPercentage(2).ToString("P")}                       {Dice2.GetDiceGuessedNum()}\n" +
                $" 3              {Dice3.GetDiceRolledNum()}               {GetDiceRolledPercentage(3).ToString("P")}                       {Dice3.GetDiceGuessedNum()}\n" +
                $" 4              {Dice4.GetDiceRolledNum()}               {GetDiceRolledPercentage(4).ToString("P")}                       {Dice4.GetDiceGuessedNum()}\n" +
                $" 5              {Dice5.GetDiceRolledNum()}               {GetDiceRolledPercentage(5).ToString("P")}                       {Dice5.GetDiceGuessedNum()}\n" +
                $" 6              {Dice6.GetDiceRolledNum()}               {GetDiceRolledPercentage(6).ToString("P")}                       {Dice6.GetDiceGuessedNum()}\n";
        }

        /// <summary>
        /// Displays the Updated Total/Win/Lost totals
        /// </summary>
        private void UpdateTotalScoreContainer()
        {
            NumberPlayedLabel.Text = $"Number of Times Played: {GamesTotal}";
            NumberWonLabel.Text = $"Number of Times Won:    {GamesWon}";
            NumberLostLabel.Text = $"Number of Times Lost: {GamesLost}";
        }

        /// <summary>
        /// Check if the User Guessed the Correct Dice that was rolled
        /// </summary>
        private void CheckGuessIsCorrect()
        {
            if (Convert.ToInt32(UserGuessTextBox.Text) == RandomNumber)
            {
                switch (Convert.ToInt32(UserGuessTextBox.Text))
                {
                    case 1:
                        Dice1.DiceGuessedCorrectly();
                        GamesWon++;
                        break;
                    case 2:
                        Dice2.DiceGuessedCorrectly();
                        GamesWon++;
                        break;
                    case 3:
                        Dice3.DiceGuessedCorrectly();
                        GamesWon++;
                        break;
                    case 4:
                        Dice4.DiceGuessedCorrectly();
                        GamesWon++;
                        break;
                    case 5:
                        Dice5.DiceGuessedCorrectly();
                        GamesWon++;
                        break;
                    case 6:
                        Dice6.DiceGuessedCorrectly();
                        GamesWon++;
                        break;
                }
            }
            else
            {
                GamesLost++;
            }
        }

        /// <summary>
        /// Update the attributes of the Dice Face that was generated by saying it was rolled one more time than before.
        /// </summary>
        private void RolledDiceUpdate()
        {
            TotalRolls++;
            switch (RandomNumber)
            {
                case 1:
                    Dice1.DiceRolled();
                    break;
                case 2:
                    Dice2.DiceRolled();
                    break;
                case 3:
                    Dice3.DiceRolled();
                    break;
                case 4:
                    Dice4.DiceRolled();
                    break;
                case 5:
                    Dice5.DiceRolled();
                    break;
                case 6:
                    Dice6.DiceRolled();
                    break;
            }
        }

        /// <summary>
        /// Update dice attributes of which dice was guessed by user.
        /// </summary>
        private void GuessedDiceUpdate()
        {
            switch (Convert.ToInt32(UserGuessTextBox.Text))
            {
                case 1:
                    Dice1.DiceGuessed();
                    break;
                case 2:
                    Dice2.DiceGuessed();
                    break;
                case 3:
                    Dice3.DiceGuessed();
                    break;
                case 4:
                    Dice4.DiceGuessed();
                    break;
                case 5:
                    Dice5.DiceGuessed();
                    break;
                case 6:
                    Dice6.DiceGuessed();
                    break;
            }
        }

        /// <summary>
        /// Checks if User has entered a valid number
        /// </summary>
        /// <returns></returns>
        private bool ValidateGuess()
        {
            int i;
            if(Int32.TryParse(UserGuessTextBox.Text, out i)) //make sure it is a integer
            {
                if (i.ToString().Length != 1) return false; //check that it is only 1 value in text box
                if (i > 6 || i < 1) //check if number is between 1-6
                {
                    //pop up error
                    return false;
                }
                return true;
                //check if int
            }
            else
            {
                return false;
            }

            return false;
        }

        /// <summary>
        /// Generates a random number between 1-6
        /// </summary>
        /// <returns></returns>
        private int RandomNumberGenerator()
        {
            Random randomNumber = new Random();
            return randomNumber.Next(1, 7);

        }
        #endregion

        /// <summary>
        /// Reset the game to defaults when reset button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetButton_Click(object sender, EventArgs e)
        {
            SetGameDefaults();
        }
    }
}
