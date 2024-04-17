using System.Reflection;
using System;
using System.Windows;

namespace WPF_Math_Game_Outline
{
    /// <summary>
    /// Interaction logic for wndHighScores.xaml
    /// </summary>
    public partial class wndHighScores : Window
    {
        /// <summary>
        /// init padawan class
        /// </summary>
        clsPadawan clsMyPadawan;

        /// <summary>
        /// init math class
        /// </summary>
        clsMath clsMyMath;

        /// <summary>
        /// consutructor for high score
        /// </summary>
        public wndHighScores()
        {
            InitializeComponent();

        }

        /// <summary>
        /// consturctor for high score with taking in padawan and math class
        /// </summary>
        /// <param name="clsMyPadawan"></param>
        /// <param name="clsMyMath"></param>
        public wndHighScores(clsPadawan clsMyPadawan, clsMath clsMyMath)
        {
            InitializeComponent();
            this.clsMyPadawan = clsMyPadawan;
            this.clsMyMath = clsMyMath;
            NameLabel.Content = clsMyPadawan.sName;
            AgeLabel.Content = clsMyMath.RandomNumber1;
        }

        /// <summary>
        /// update the high score board with values
        /// </summary>
        public void updateValue()
        {
            try
            {
                NameLabel.Content = clsMyPadawan.sName;
                AgeLabel.Content = clsMyPadawan.iAge;
                CorrectLabel.Content = clsMyMath.CorrectGuess;
                IncorrectLabel.Content = clsMyMath.WrongGuess;
                TimeLabel.Content = clsMyMath.time;
            } catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// close the high score screen when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCloseHighScores_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Hide();
            } catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// closing the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                this.Hide();
                e.Cancel = true;
            } catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
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

    }
}
