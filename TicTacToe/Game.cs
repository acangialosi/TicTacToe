using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Game
    {
        static int dimension = 3;
        private static char emptyCell = ' ';

        public static void PlayGame()
        {
 
            char[,] gameBoard;
                int currentPlayer = 0; // 0 == X 1 == Y
                string strMove;
                int moveCount;
                Tuple<int, int> move = new Tuple<int, int>(0, 0);

            gameBoard = new char[dimension, dimension];

            ClearBoard(gameBoard);

            do
            {
                ClearBoard(gameBoard);
                Console.Write("Decide who is player 'X' and who is player 'O' then press any key to start the game.");
                Console.ReadLine();
                strMove = "";
                moveCount = -1;

                while (!EndOfGame(gameBoard, PrintPlayer(currentPlayer), move))
                {
                    moveCount++;
                    currentPlayer = moveCount % 2;
                    PrintBoard(gameBoard);
                    Console.Write("Player {0}, make your move: ", PrintPlayer(currentPlayer));
                    strMove = Console.ReadLine();

                    try
                    {
                        move = ConvertMove(strMove);
                        SetMove(gameBoard, move, PrintPlayer(currentPlayer));
                    }
                    catch (Exception ex)
                    {
                        if (ex is InvalidMoveException || ex is IndexOutOfRangeException)
                        {
                            Console.WriteLine();
                            Console.WriteLine("INVALID MOVE");
                            Console.WriteLine();
                            moveCount--;
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                PrintBoard(gameBoard);
                Console.WriteLine("Congratultaions player {0}. YOU'VE WON!", PrintPlayer(currentPlayer));

            } while (NewGame());

            Console.WriteLine("Thanks for playing!");
        }

        public static bool NewGame()
        {
            bool returnValue = false;
            Console.WriteLine("Would you like to play another game? [y/n]");
            string playAgain;
            playAgain = Console.ReadLine();
            if (playAgain == "y")
            {
                returnValue = true;
            }
            else if (playAgain == "n")
            {
                returnValue = false;
            }
            else
            {
                returnValue = NewGame();
            }

            return returnValue;
        }

        public static bool EndOfGame(char[,] board, char player, Tuple<int, int> move)
        {
            // Check column
            for (int y = 0; y < dimension; y++)
            {
                if (player != board[move.Item1, y])
                {
                    break;
                }

                if (y == dimension - 1)
                {
                    return true;
                }
            }

            // Check row
            for (int x = 0; x < dimension; x++)
            {
                if (player != board[x, move.Item2])
                {
                    break;
                }

                if (x == dimension - 1)
                {
                    return true;
                }
            }

            // Check Diagnol
            for (int n = 0; n < dimension; n++)
            {
                if (player != board[n, n])
                {
                    break;
                }

                if (n == dimension - 1)
                {
                    return true;
                }
            }


            // Check Anti-Diagnol
            for (int n = 0; n < dimension; n++)
            {

                if (player != board[(dimension - 1) - n, 0 + n])
                {
                    break;
                }

                if (n == dimension - 1)
                {
                    return true;
                }
            }

            return false;
        }

        public static string GetSeperatorLine()
        {
            int seperatorLength = (dimension) * 3 + dimension - 1;
            string seperator = "";
            for (int x = 0; x < seperatorLength; x++)
            {
                seperator += "-";
            }

            return seperator;
        }

        public static void PrintBoard(char[,] board)
        {
            string seperator = GetSeperatorLine();
            for (int y = 0; y < dimension; y++)
            {
                Console.WriteLine(seperator);
                for (int x = 0; x < dimension; x++)
                {
                    if (x == 0)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(board[x, y]);
                    if (x + 1 < dimension)
                    {
                        Console.Write(" | ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine(seperator);
        }

        public static char PrintPlayer(int player)
        {
            if (player == 0)
            {
                return 'X';
            }
            else
                return 'O';
        }

        public static void SetMove(char[,] board, Tuple<int, int> move, char player)
        {
            if (board[move.Item1, move.Item2] != emptyCell)
            {
                throw new InvalidMoveException();
            }

            board[move.Item1, move.Item2] = player;
        }

        public static Tuple<int, int> ConvertMove(string move)
        {
            Tuple<int, int> returnValue;
            try
            {
                string[] parts = move.Split(',');
                returnValue = new Tuple<int, int>(int.Parse(parts[0]), int.Parse(parts[1]));
            }
            catch (Exception)
            {
                throw new InvalidMoveException();
            }

            return returnValue;
        }

        public static void ClearBoard(char[,] board)
        {
            for (int x = 0; x < dimension; x++)
            {
                for (int y = 0; y < dimension; y++)
                {
                    board[x, y] = emptyCell;
                }
            }
        }
    }
}
