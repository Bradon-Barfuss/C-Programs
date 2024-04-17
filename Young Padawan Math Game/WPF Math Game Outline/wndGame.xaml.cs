using System;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;

namespace WPF_Math_Game_Outline
{
    /// <summary>
    /// Interaction logic for wndGame.xaml
    /// </summary>
    public partial class wndGame : Window
    {
        /// <summary>
        /// Variable to hold the high scores form.
        /// </summary>
        private wndHighScores wndCopyHighScores;

        /// <summary>
        /// set up the enum types in the class
        /// </summary>
        Operations.MathType Type;

        /// <summary>
        /// delcaring the math class
        /// </summary>
        clsMath clsMyMath;

        /// <summary>
        /// Setting up things to use a timer
        /// </summary>
        DispatcherTimer MyTimer;

        /// <summary>
        /// how many second the game has been running
        /// </summary>
        int sec = 0;

        /// <summary>
        /// a boolean to check if the game has started yet
        /// </summary>
        public bool isStartPressed = false;

        /// <summary>
        /// Property to get and set the high scores.
        /// </summary>
        public wndHighScores CopyHighScores
        {
            get { return wndCopyHighScores; }
            set { wndCopyHighScores = value; }
        }

        /// <summary>
        /// initizle the game
        /// </summary>
        public wndGame()
        {
            InitializeComponent();
        }

        /// <summary>
        /// initilize the game with math class into it
        /// </summary>
        /// <param name="MyMath"></param>
        public wndGame(clsMath MyMath)
        {
            InitializeComponent();
            clsMyMath = MyMath;
            MyTimer = new DispatcherTimer();
            MyTimer.Interval = TimeSpan.FromSeconds(1);
            MyTimer.Tick += new EventHandler(MyTimer_Tick);
        }

        /// <summary>
        /// use to update visual timer on screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        void MyTimer_Tick(object sender, EventArgs e)
        {
            try { 
            sec++;
            timerLabel.Content = sec;
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// when the end game is clicked in the game window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdEndGame_Click(object sender, RoutedEventArgs e)
        {
            try {
                reset();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// when the end game is clicked in the game window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdEndGameReached()
        {
            try
            {
                reset();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// reset the game status and high scores
        /// </summary>
        /// <exception cref="Exception"></exception>
        private void reset()
        {
            try
            {
                isStartPressed = false;
                JediAnswerTextBox.Text = string.Empty;
                JediAnswerTextBox.IsEnabled = false;
                clsMyMath.time = sec;
                sec = 0;
                MyTimer.Stop();
                this.Hide();
                wndCopyHighScores.updateValue();
                wndCopyHighScores.ShowDialog();
                timerLabel.Content = sec;
                clsMyMath.WrongGuess = 0;
                clsMyMath.CorrectGuess = 0;
            } catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }

        /// <summary>
        /// When the High Score button is clicked from the game window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdHighScores_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                reset();

            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// When the close window function is called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try {
                this.Hide();
                e.Cancel = true;
            } catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// Set up the math game depending on the operation type
        /// </summary>
        /// <param name="type"></param>
        public void setUpGameMath(Operations.MathType type)
        {
            try
            {
                Type = type;
                if (Type == Operations.MathType.Add)
                {
                    updateGameAddition();
                }
                else if (Type == Operations.MathType.Subtract)
                {
                    updateGameSubtraction();
                }
                else if (Type == Operations.MathType.Multiply)
                {
                    updateGameMulplication();
                }
                else if (Type == Operations.MathType.Divide)
                {
                    updateGameDivision();
                }
            } catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }
       
        /// <summary>
        /// When the young jedi sumbits there answer, this code will run
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSumbit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(clsMyMath.CorrectGuess + clsMyMath.WrongGuess >= 9)
                {
                    clsMyMath.isCorrectGuess(int.Parse(JediAnswerTextBox.Text));
                    cmdEndGameReached();
                }
                if (isStartPressed == true)
                {
                    if (Type == Operations.MathType.Add)
                    {
                        DisplayValidAnswerLabel();
                        updateGameAddition();
                        JediAnswerTextBox.Text = "";

                    }
                    else if (Type == Operations.MathType.Subtract)
                    {
                        DisplayValidAnswerLabel();
                        updateGameSubtraction();
                        JediAnswerTextBox.Text = "";

                    }
                    else if (Type == Operations.MathType.Multiply)
                    {
                        DisplayValidAnswerLabel();
                        updateGameMulplication();
                        JediAnswerTextBox.Text = "";

                    }
                    else if (Type == Operations.MathType.Divide)
                    {
                        DisplayValidAnswerLabel();
                        updateGameDivision();
                        JediAnswerTextBox.Text = "";

                    }
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);

            }
        }

        /// <summary>
        /// update the display of if the user got the correct or wrong answer
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void DisplayValidAnswerLabel()
        {
            try
            {
                if (clsMyMath.isCorrectGuess(int.Parse(JediAnswerTextBox.Text)) == true)
                {
                    CorrectOrWrongLabel.Content = "Correct!";
                }
                else
                {
                    CorrectOrWrongLabel.Content = "Wrong!";
                }
            } catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// update the numbers on the screen for the jedi to calculate for subtraction
        /// </summary> 
        public void updateGameAddition()
        {
            try
            {
                clsMyMath.GenerateAddition(); //update the random number in the math class
                LabelNumber1.Content = clsMyMath.RandomNumber1;
                LabelNumber2.Content = clsMyMath.RandomNumber2;
                LabelSignType.Content = "+";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// update the numbers on the screen for the jedi to calculate for subtraction
        /// </summary>
        public void updateGameSubtraction()
        {
            try
            {
                clsMyMath.GenerateSubtraction(); //update the random number in the math class
                LabelNumber1.Content = clsMyMath.RandomNumber1;
                LabelNumber2.Content = clsMyMath.RandomNumber2;
                LabelSignType.Content = "-";

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// update the numbers on the screen for the jedi to calculate for Muliplication
        /// </summary>
        public void updateGameMulplication()
        {
            try
            {
                clsMyMath.GenerateMulplication(); //update the random number in the math class
                LabelNumber1.Content = clsMyMath.RandomNumber1;
                LabelNumber2.Content = clsMyMath.RandomNumber2;
                LabelSignType.Content = "*";

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// update the numbers on the screen for the jedi to calculate for Muliplication
        /// </summary>
        public void updateGameDivision()
        {
            try
            {
                clsMyMath.GenerateDivision(); //update the random number in the math class
                LabelNumber1.Content = clsMyMath.RandomNumber1;
                LabelNumber2.Content = clsMyMath.RandomNumber2;
                LabelSignType.Content = "/";

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// when the player clicks the start button, it will let the game know the user can start playing the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdStart_Click(object sender, RoutedEventArgs e)
        {
            try {
                isStartPressed = true;
                JediAnswerTextBox.IsEnabled = true;
                MyTimer.Start();


            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// handle error method
        /// </summary>
        /// <param name="sClass"></param>
        /// <param name="sMethod"></param>
        /// <param name="sMessage"></param>
        public static void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " ->" + sMessage);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Users\bradon and lauren\\Box\\Bradon\\CS3280\\Week 5\\Assingment_5\\Error.txt", Environment.NewLine + "HandleError Execption: " + ex.Message);
            }
        }

        /// <summary>
        /// when the user press enter, it will check if they have the right answer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JediAnswerTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if (e.Key == System.Windows.Input.Key.Enter)
                {

                    if (clsMyMath.CorrectGuess + clsMyMath.WrongGuess >= 9)
                    {
                        clsMyMath.isCorrectGuess(int.Parse(JediAnswerTextBox.Text));
                        cmdEndGameReached();
                    }
                    if (isStartPressed == true)
                    {
                        if (Type == Operations.MathType.Add)
                        {
                            DisplayValidAnswerLabel();
                            updateGameAddition();
                            JediAnswerTextBox.Text = "";

                        }
                        else if (Type == Operations.MathType.Subtract)
                        {
                            DisplayValidAnswerLabel();
                            updateGameSubtraction();
                            JediAnswerTextBox.Text = "";

                        }
                        else if (Type == Operations.MathType.Multiply)
                        {
                            DisplayValidAnswerLabel();
                            updateGameMulplication();
                            JediAnswerTextBox.Text = "";

                        }
                        else if (Type == Operations.MathType.Divide)
                        {
                            DisplayValidAnswerLabel();
                            updateGameDivision();
                            JediAnswerTextBox.Text = "";

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);

            }

        }
    }
}
