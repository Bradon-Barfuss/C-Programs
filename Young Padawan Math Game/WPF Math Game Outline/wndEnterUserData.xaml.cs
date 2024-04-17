using System;
using System.Reflection;
using System.Windows;

namespace WPF_Math_Game_Outline
{
    /// <summary>
    /// Interaction logic for wndEnterUserData.xaml
    /// </summary>
    public partial class wndEnterUserData : Window
    {

        /// <summary>
        /// obejct reference to user (padawan) class
        /// </summary>
        clsPadawan clsMyPadawan;

        /// <summary>
        /// constructin gthe enter user data window
        /// </summary>
        public wndEnterUserData()
        {
            InitializeComponent();
        }

        /// <summary>
        /// consturctor with having the user (mypadawan) class
        /// </summary>
        /// <param name="MyPadawan"></param>
        public wndEnterUserData(clsPadawan MyPadawan)
        {
            InitializeComponent();
            clsMyPadawan = MyPadawan;
        }

        /// <summary>
        /// closes the Jedi Data Form window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCloseUserDataForm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Hide user data form
                this.Hide();

            } catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// method for closing the window
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
        /// Check for valid Vedi input Name
        /// </summary>
        /// <returns></returns>
        public Boolean isValidJediName()
        {
            try
            {
                return clsMyPadawan.isValidName(JediNameTextBox.Text);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);

            }
        }

        /// <summary>
        /// check if there is a valid jedi age entered
        /// </summary>
        /// <returns></returns>
        public Boolean isValidJediAge()
        {
            try
            {
                return clsMyPadawan.isValidAge(int.Parse(JediAgeTextBox.Text));
            } catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);

            }
        }

        /// <summary>
        /// check if a valid radio option was selected
        /// </summary>
        /// <returns></returns>
        public Boolean isValidMathOption()
        {
            try
            {
                if (AddRadioButton.IsChecked == false && SubtractRadioButton.IsChecked == false && MultiplyRadioButton.IsChecked == false && DivideRadioButton.IsChecked == false)
                {
                    return false;
                }
                return true;
             }catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);

            }
        }

        /// <summary>
        /// returns what type of game will be played
        /// </summary>
        /// <returns></returns>
        public Operations.MathType WhatMathType()
        {
            try {
                if (AddRadioButton.IsChecked == true) { return Operations.MathType.Add; }
                else if (SubtractRadioButton.IsChecked == true) { return Operations.MathType.Subtract; }
                else if (MultiplyRadioButton.IsChecked == true) { return Operations.MathType.Multiply; }
                else { return Operations.MathType.Divide; }
            } catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

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

    }
}
