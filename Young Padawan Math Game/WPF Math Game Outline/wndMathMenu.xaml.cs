using System;
using System.Media;
using System.Reflection;
using System.Windows;
using System.Windows.Input; 



namespace WPF_Math_Game_Outline
{

    /// <summary>
    /// Interaction logic for wndMathMenu.xaml
    /// </summary>
    public partial class wndMathMenu : Window
    {

        /// <summary>
        /// Class that holds the high scores.
        /// </summary>
        wndHighScores wndHighScoresForm;

        /// <summary>
        /// Class that holds the user data.
        /// </summary>
        wndEnterUserData wndEnterUserDataForm;

        /// <summary>
        /// Class where the game is played.
        /// </summary>
        wndGame wndGameForm;

        /// <summary>
        /// jedi class
        /// </summary>
        clsPadawan clsMyPadawan;

        /// <summary>
        /// math logic
        /// </summary>
        clsMath clsMyMath;

        /// <summary>
        /// A function that handles the errors
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
        /// the consuctor for the mathmenu class
        /// </summary>
        public wndMathMenu()
        {
            SoundPlayer player = new SoundPlayer("MainTitle.wav");
           player.PlayLooping();

            InitializeComponent();

            //MAKE SURE TO INCLUDE THIS LINE OR THE APPLICATION WILL NOT CLOSE
            //BECAUSE THE WINDOWS ARE STILL IN MEMORY
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;///////////////////////////////////////////////////////////

            clsMyPadawan = new clsPadawan();
            clsMyMath = new clsMath();
            wndEnterUserDataForm = new wndEnterUserData(clsMyPadawan);
            wndGameForm = new wndGame(clsMyMath);
            wndHighScoresForm = new wndHighScores(clsMyPadawan, clsMyMath);


            //Pass the high scores form to the game form.  This way the high scores form may be displayed via the game form.
            wndGameForm.CopyHighScores = wndHighScoresForm;
        }

        /// <summary>
        /// When the Player Clicks the start game in the main menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdPlayGame_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isJediValid() == true)
                {
                    //Hide the menu
                    this.Hide();

                    //Set up the game
                    wndGameForm.setUpGameMath(wndEnterUserDataForm.WhatMathType());

                    //Show the game form
                    wndGameForm.ShowDialog();
                    //Show the main form
                    this.Show();
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Check if the jedi added the valid inputs
        /// </summary>
        /// <returns></returns>
        public Boolean isJediValid()
        {
            try
            {
                if (wndEnterUserDataForm.isValidJediName() == false)
                {
                    ErrorLabelJediInput.Content = "Enter Valid Jedi Name Please";
                    return false;
                }
                if (wndEnterUserDataForm.isValidJediAge() == false)
                {
                    ErrorLabelJediInput.Content = "Enter Valid Jedi Age Please (3 - 10)";
                    return false;
                }

                if (wndEnterUserDataForm.isValidMathOption() == false)
                {
                    ErrorLabelJediInput.Content = "Click Game Type Option";
                    return false;
                }
                ErrorLabelJediInput.Content = "";

                return true;
            } catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// When the high score button is clicked, it will display the high score menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdHighScores_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Hide the menu
                this.Hide();
                //Show the high scores screen
                wndHighScoresForm.ShowDialog();
                //Show the main form
                this.Show();
            } catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Display the jedi information menu when the enter data button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdEnterUserData_Click(object sender, RoutedEventArgs e)
        {
            try {
                //Hide the menu
                this.Hide();
                //Show the user data form
                wndEnterUserDataForm.ShowDialog();
                //Show the main form
                this.Show();
            } catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}
