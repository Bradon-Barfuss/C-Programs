using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;


namespace WPF_Math_Game_Outline
{
    public class clsMath
    {


        /// <summary>
        /// Randomly generated number for user to guess
        /// </summary>
        public int RandomNumber1 { get; set; }
        /// <summary>
        /// second randly generated number for the user to guess
        /// </summary>
        public int RandomNumber2 { get; set; }
        /// <summary>
        /// the correct number the user needs to guess
        /// </summary>
        public int CorrectNumber {  get; set; }

        /// <summary>
        /// the amount of time that has passed
        /// </summary>
        public int time {  get; set; }

        /// <summary>
        /// Number ofguess that were done correctly
        /// </summary>
        public int CorrectGuess { get; set; }
        /// <summary>
        /// number of guess that were incorrect
        /// </summary>
        public int WrongGuess { get; set; }

        /// <summary>
        /// setting the random class
        /// </summary>
        Random rNum = new Random();

        public clsMath(MathType type)
        {

        }

        /// <summary>
        /// how many second the game has been running
        /// </summary>
        int sec = 0;

        /// <summary>
        /// constructing the cls Math
        /// </summary>
        public clsMath()
        {
            CorrectGuess = 0;
            WrongGuess = 0;

        }

        /// <summary>
        /// Checking if the guess is correct
        /// </summary>
        /// <param name="guess"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool isCorrectGuess(int guess)
        {
            try
            {
                if(guess == CorrectNumber)
                {
                    CorrectGuess++;
                    return true;
                } 
                else
                {
                    WrongGuess++;
                    return false;
                }
            } catch (Exception ex) {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

    /// <summary>
    /// Generates randomly generated numbers and set the correct guess value of addition
    /// </summary>
    /// <exception cref="Exception"></exception>
        public void GenerateAddition()
        {
            try
            {
                RandomNumber1 = rNum.Next(1, 10);
                RandomNumber2 = rNum.Next(1, 10);

                CorrectNumber = RandomNumber1 + RandomNumber2;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// Generates randomly generated numbers and set the correct guess value of subtraction
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void GenerateSubtraction()
        {
            try
            {
                RandomNumber1 = rNum.Next(1, 10);
                RandomNumber2 = rNum.Next(1, 10);
                while (RandomNumber1 < RandomNumber2)
                {
                    RandomNumber2 = rNum.Next(1, 10);
                }
                CorrectNumber = RandomNumber1 - RandomNumber2;
            } catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// Generates randomly generated numbers and set the correct guess value of multiplying
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void GenerateMulplication()
        {
            try
            {
                RandomNumber1 = rNum.Next(1, 10);
                RandomNumber2 = rNum.Next(1, 10);
                CorrectNumber = RandomNumber1 * RandomNumber2;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// Generates randomly generated numbers and set the correct guess value of Dividing
        /// </summary>
        /// <exception cref="Exception"></exception>

        ///  For division you are welcome to use numbers a little larger than 10, because the game ends up with a lot of division questions where the answer is one. 
        ///  So, for division you can pick two numbers between 1 and 10, multiply them, use that number for the first number.  Here is an example. 
        ///  Let’s say the program randomly selects the numbers 3 and 5.  
        ///  First multiply them together, which gives you 15.  Now use 15 as the first number, 3 as the second number, and 5 as the answer.
        public void GenerateDivision()
        {
            try
            {

                RandomNumber1 = rNum.Next(1, 10);
                RandomNumber2 = rNum.Next(1, 10);
                RandomNumber1 = RandomNumber2 * RandomNumber1;
                CorrectNumber = RandomNumber1 / RandomNumber2;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }
    }
}
