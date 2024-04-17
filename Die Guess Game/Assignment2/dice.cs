using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    /// <summary>
    /// Dice class, used to track information for each specific Dice Number.
    /// </summary>
    internal class dice
    {
        #region Attributes
        /// <summary>
        /// The Face Number of the Dice
        /// </summary>
        private int DiceFaceNumber;

        /// <summary>
        /// How many times this dice has been rolled
        /// </summary>
        private int NumDiceRolled;

        /// <summary>
        /// Number of times this dice has been guessed
        /// </summary>
        private int NumDiceGuessed;

        /// <summary>
        /// How Many Times the Dice has been Guessed Correctly
        /// </summary>
        private int NumDiceGuessedCorrectly;
        #endregion

        #region Methods

        /// <summary>
        /// Setting the inital Dice attributes
        /// </summary>
        /// <param name="DiceFace"></param>
        public dice(int DiceFace)
        {
            DiceFaceNumber = DiceFace;
            NumDiceRolled = 0;
            NumDiceGuessed = 0;
            NumDiceGuessedCorrectly = 0;
        }

        /// <summary>
        /// Add to the count how many times that dice has been rolled
        /// </summary>
        public void DiceRolled()
        {
            NumDiceRolled++;
        }

        /// <summary>
        /// Add to the count how many times that dice has been guessed
        /// </summary>
        public void DiceGuessed()
        {
            NumDiceGuessed++;
        }

        /// <summary>
        /// Add to the count of dice that was guessed correctly
        /// </summary>
        public void DiceGuessedCorrectly()
        {
            NumDiceGuessedCorrectly++;
        }

        /// <summary>
        /// reset game values
        /// </summary>
        public void reset()
        {
            NumDiceRolled = 0;
            NumDiceGuessed = 0;
            NumDiceGuessedCorrectly = 0;
        }

        /// <summary>
        /// Return how many times this dice has been rolled
        /// </summary>
        /// <returns></returns>
        public int GetDiceRolledNum()
        {
            return NumDiceRolled;
        }

        /// <summary>
        /// Return how many times this dice has been guessed
        /// </summary>
        /// <returns></returns>
        public int GetDiceGuessedNum() { return NumDiceGuessed;}

        /// <summary>
        /// Return how many times the dice has been guessed correctly
        /// </summary>
        /// <returns></returns>
        public int GetDiceGuessedCorrectlyNum() {  return NumDiceGuessedCorrectly; }
        #endregion

    }
}
