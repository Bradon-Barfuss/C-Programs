using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace TicTacToe
{
    class clsTicTacToe
    {

        /// <summary>
        /// The 3by3 string array representing the tic tac toe board
        /// </summary>
        private string[,] Board;

        /// <summary>
        /// number of times player one has won
        /// </summary>
        private int iPlayer1Wins;

        /// <summary>
        /// number of times player two has won
        /// </summary>
        private int iPlayer2Wins;

        /// <summary>
        /// number of ties in the game
        /// </summary>
        private int iTies;

        public enum WinningMove
        {
            Row1 = 1,
            Row2 = 2,
            Row3 = 3,
            Col1 = 4,
            Col2 = 5,
            Col3 = 6,
            Diag1 = 7,
            Diag2 = 8,
            Tie = 9
        }

        /// <summary>
        /// init the business class
        /// </summary>
        public clsTicTacToe()
        {
            Board = new string[3, 3];
            iPlayer1Wins = 0;
            iPlayer2Wins = 0;
        }

        /// <summary>
        /// reset the string array
        /// </summary>
        public void resetSBoard()
        {
            for(int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Board[i, j] = null;
                }
            }
        }

        /// <summary>
        /// check if there is a winning move
        /// </summary>
        /// <returns></returns>
        public bool isWinningMove()
        {
            if (Board[0, 0] == Board[0, 1] && Board[0, 1] == Board[0, 2] && Board[0, 2] != null) return true;
            else if (Board[1, 0] == Board[1, 1] && Board[1, 1] == Board[1, 2] && Board[1, 2] != null) return true;           
            else if (Board[2, 0] == Board[2, 1] && Board[2, 1] == Board[2, 2] && Board[2, 2] != null) return true;
            else if (Board[0, 0] == Board[1, 0] && Board[1, 0] == Board[2, 0] && Board[2, 0] != null) return true;
            else if (Board[0, 1] == Board[1, 1] && Board[1, 1] == Board[2, 1] && Board[2, 1] != null) return true;
            else if (Board[0, 2] == Board[1, 2] && Board[1, 2] == Board[2, 2] && Board[2, 2] != null) return true;
            else if (Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2] && Board[2, 2] != null) return true;
            else if (Board[2, 0] == Board[1, 1] && Board[1, 1] == Board[0, 2] && Board[0, 2] != null) return true;
            foreach (var i in Board)
            {
                if (i == null) { return false; }
            }
            return true;
        }

        /// <summary>
        /// return what combination was the winning move
        /// </summary>
        /// <returns></returns>
        public int whatIsWinningMove()
        {
            if (Board[0, 0] == Board[0, 1] && Board[0, 1] == Board[0, 2] && Board[0, 2] != null) return (int)WinningMove.Row1;
            else if (Board[1, 0] == Board[1, 1] && Board[1, 1] == Board[1, 2] && Board[1, 2] != null) return (int)WinningMove.Row2;
            else if (Board[2, 0] == Board[2, 1] && Board[2, 1] == Board[2, 2] && Board[2, 2] != null) return (int)WinningMove.Row3;
            else if (Board[0, 0] == Board[1, 0] && Board[1, 0] == Board[2, 0] && Board[2, 0] != null) return (int)WinningMove.Col1;
            else if (Board[0, 1] == Board[1, 1] && Board[1, 1] == Board[2, 1] && Board[2, 1] != null) return (int)WinningMove.Col2;
            else if (Board[0, 2] == Board[1, 2] && Board[1, 2] == Board[2, 2] && Board[2, 2] != null) return (int)WinningMove.Col3;
            else if (Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2] && Board[2, 2] != null) return (int)WinningMove.Diag1;
            else if (Board[2, 0] == Board[1, 1] && Board[1, 1] == Board[0, 2] && Board[0, 2] != null) return (int)WinningMove.Diag2;
            return (int)WinningMove.Tie;
         
        }

        /// <summary>
        /// put value into the board string array
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="value"></param>
        public void IntoBoard(int x, int y, string value)
        {
            Board[x, y] = value;
        }

        /// <summary>
        /// add to the total number of times how many each player has won
        /// </summary>
        /// <param name="whichPlayer"></param>
        public void AddToPlayerScore(int whichPlayer)
        {
            if(whichPlayer == 1)
            {
                iPlayer1Wins++;
            }
            else
            {
                iPlayer2Wins++;
            }
        }
        /// <summary>
        /// add to the total number of ties
        /// </summary>
        public void AddToTie()
        {
            iTies++;
        }

        /// <summary>
        /// return the count of how many times player one has won
        /// </summary>
        /// <returns></returns>
        public int GetPlayer1Wins()
        {
            return iPlayer1Wins;
        }

        /// <summary>
        /// return the number of times player two has won
        /// </summary>
        /// <returns></returns>
        public int GetPlayer2Wins()
        {
            return iPlayer2Wins;
        }

        /// <summary>
        /// return the number of times ties has happened
        /// </summary>
        /// <returns></returns>
        public int GetTies()
        {
            return iTies;
        }
    }
}
