using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ///
        clsTicTacToe TicTacToe;
        /// <summary>
        /// see if the game has started
        /// </summary>
        bool bHasGameStarted;

        /// <summary>
        /// See which player turn it is
        /// </summary>
        int playerTurn;

        /// <summary>
        /// See which combination of x or o causes the game to win
        /// </summary>
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
        }

        /// <summary>
        /// initize the window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            TicTacToe = new clsTicTacToe();
        }

        /// <summary>
        /// when the start game button is clicked, it will reset the board to its defaults
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bHasGameStarted = true;
            playerTurn = 1;
            Reset();
        }

        /// <summary>
        /// When the mouse clicks on of the tiles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayerMoveClick(object sender, MouseButtonEventArgs e)
        {
            if (bHasGameStarted) //if game has started
            {
                Label MyLabel = (Label)sender;

                if(MyLabel.Content == null) //if tile is empty
                {
                    if (playerTurn == 1) //Determines if tile will be X or O
                    {
                        MyLabel.Content = "O";
                        playerTurn = 2;
                    } else { MyLabel.Content = "X";
                        playerTurn = 1;
                    }
                    TicTacToe.IntoBoard(Grid.GetColumn(MyLabel), Grid.GetRow(MyLabel), Convert.ToString(MyLabel.Content));
                    if(TicTacToe.isWinningMove() == true)
                    {
                        ColorLabels(TicTacToe.whatIsWinningMove());
                        if (TicTacToe.whatIsWinningMove() == 9) { TicTacToe.AddToTie(); DisplayTie(); } else { TicTacToe.AddToPlayerScore(playerTurn); DisplayWinner(); }
                        
                        UpdateScoreDisplay();
                        bHasGameStarted = false;
                    }
                    

                }

            }
        }

        /// <summary>
        /// color the winning combinations of moves
        /// </summary>
        /// <param name="i"></param>
        private void ColorLabels(int i)
        {
            if (i == (int) WinningMove.Row1)
            {
                Label0_0.Background = new SolidColorBrush(Colors.LightBlue);
                Label0_1.Background = new SolidColorBrush(Colors.LightBlue);
                Label0_2.Background = new SolidColorBrush(Colors.LightBlue);
            }
            else if (i == (int)WinningMove.Row2)
            {
                Label1_0.Background = new SolidColorBrush(Colors.LightBlue);
                Label1_1.Background = new SolidColorBrush(Colors.LightBlue);
                Label1_2.Background = new SolidColorBrush(Colors.LightBlue);
            }
            else if (i == (int)WinningMove.Row3)
            {
                Label2_0.Background = new SolidColorBrush(Colors.LightBlue);
                Label2_1.Background = new SolidColorBrush(Colors.LightBlue);
                Label2_2.Background = new SolidColorBrush(Colors.LightBlue);
            }
            else if (i == (int)WinningMove.Col1)
            {
                Label0_0.Background = new SolidColorBrush(Colors.LightBlue);
                Label1_0.Background = new SolidColorBrush(Colors.LightBlue);
                Label2_0.Background = new SolidColorBrush(Colors.LightBlue);
            }
            else if (i == (int)WinningMove.Col2)
            {
                Label0_1.Background = new SolidColorBrush(Colors.LightBlue);
                Label1_1.Background = new SolidColorBrush(Colors.LightBlue);
                Label2_1.Background = new SolidColorBrush(Colors.LightBlue);
            }
            else if (i == (int)WinningMove.Col3)
            {
                Label0_2.Background = new SolidColorBrush(Colors.LightBlue);
                Label1_2.Background = new SolidColorBrush(Colors.LightBlue);
                Label2_2.Background = new SolidColorBrush(Colors.LightBlue);
            }
            else if (i == (int)WinningMove.Diag1)
            {
                Label0_0.Background = new SolidColorBrush(Colors.LightBlue);
                Label1_1.Background = new SolidColorBrush(Colors.LightBlue);
                Label2_2.Background = new SolidColorBrush(Colors.LightBlue);
            }
            else if (i == (int)WinningMove.Diag2)
            {
                Label2_0.Background = new SolidColorBrush(Colors.LightBlue);
                Label1_1.Background = new SolidColorBrush(Colors.LightBlue);
                Label0_2.Background = new SolidColorBrush(Colors.LightBlue);
            }
        }

        /// <summary>
        /// display the winner who won that game
        /// </summary>
        private void DisplayWinner()
        {
            TBDisplayWinner.Text = "Player " + playerTurn + " wins!";
        }

        /// <summary>
        /// display that it was a tie
        /// </summary>
        private void DisplayTie()
        {
            TBDisplayWinner.Text = "It is a tie!";
        }

        /// <summary>
        /// update the score board
        /// </summary>
        private void UpdateScoreDisplay()
        {
            TBScoreBoard.Text = "Player One Wins: " + TicTacToe.GetPlayer1Wins() + "\r\n Player Two Wins: " + TicTacToe.GetPlayer2Wins() + "\r\n Ties: " + TicTacToe.GetTies();
        }

        /// <summary>
        /// reset the game
        /// </summary>
        private void Reset()
        {
            TBDisplayWinner.Text = " ";
            TBScoreBoard.Text = "Player One Wins: " + TicTacToe.GetPlayer1Wins() + "\r\n Player Two Wins: " + TicTacToe.GetPlayer2Wins() + "\r\n Ties: " + TicTacToe.GetTies();
            ResetTilesColors();
            ResetTilesContents();
            TicTacToe.resetSBoard();
        }

        /// <summary>
        /// reset the color of tiles
        /// </summary>
        private void ResetTilesColors()
        {
            Label0_0.Background = new SolidColorBrush(Colors.White);
            Label0_1.Background = new SolidColorBrush(Colors.White);
            Label0_2.Background = new SolidColorBrush(Colors.White);
            Label1_0.Background = new SolidColorBrush(Colors.White);
            Label1_1.Background = new SolidColorBrush(Colors.White);
            Label1_2.Background = new SolidColorBrush(Colors.White);
            Label2_0.Background = new SolidColorBrush(Colors.White);
            Label2_1.Background = new SolidColorBrush(Colors.White);
            Label2_2.Background = new SolidColorBrush(Colors.White);
            Label0_0.Background = new SolidColorBrush(Colors.White);
            Label1_0.Background = new SolidColorBrush(Colors.White);
            Label2_0.Background = new SolidColorBrush(Colors.White);
            Label0_1.Background = new SolidColorBrush(Colors.White);
            Label1_1.Background = new SolidColorBrush(Colors.White);
            Label2_1.Background = new SolidColorBrush(Colors.White);
            Label0_2.Background = new SolidColorBrush(Colors.White);
            Label1_2.Background = new SolidColorBrush(Colors.White);
            Label2_2.Background = new SolidColorBrush(Colors.White);
            BorderL.Background = new SolidColorBrush(Colors.Black);
            BorderR.Background = new SolidColorBrush(Colors.Black);
            BorderT.Background = new SolidColorBrush(Colors.Black);
            BorderB.Background = new SolidColorBrush(Colors.Black);

        }

        /// <summary>
        /// reset the content of each tile, i.e. remove 'x's and 'o's
        /// </summary>
    private void ResetTilesContents()
        {
            Label0_1.Content = null;
            Label0_2.Content = null;
            Label1_0.Content = null;
            Label1_1.Content = null;
            Label1_2.Content = null;
            Label2_0.Content = null;
            Label2_1.Content = null;
            Label2_2.Content = null;
            Label0_0.Content = null;
            Label1_0.Content = null;
            Label2_0.Content = null;
            Label0_1.Content = null;
            Label1_1.Content = null;
            Label2_1.Content = null;
            Label0_2.Content = null;
            Label1_2.Content = null;
            Label2_2.Content = null;
        }
    }
}