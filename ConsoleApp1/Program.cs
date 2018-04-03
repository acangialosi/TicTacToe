using System;

namespace ConsoleApp1
{
    class Program
    {
        static int dimension = 3;
        private static char emptyCell = ' ';

        static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                dimension = int.Parse(args[0]);
            }

            PlayGame();
        }

        private static void PlayGame()
        {
            char[,] gameBoard;
            int currentPlayer = 0; // 0 == X 1 == Y
            int moveCount = -1;

            gameBoard = new char[dimension,dimension];

            ClearBoard(gameBoard);

            do
            {
                ClearBoard(gameBoard);
                Console.Write("Decide who is player 'X' and who is player 'O' then press any key to start the game.");
                Console.ReadLine();
                string strMove = "";

                while (!EndOfGame(gameBoard, PrintPlayer(currentPlayer)))
                {
                    moveCount++;
                    currentPlayer = moveCount % 2;
                    PrintBoard(gameBoard);
                    Console.Write("Player {0}, make your move: ", PrintPlayer(currentPlayer));
                    strMove = Console.ReadLine();

                    try
                    {
                        Tuple<int, int> move = ConvertMove(strMove);
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
                Console.WriteLine("Congratultaions player {0}. YOU WON!", PrintPlayer(currentPlayer));

            } while (NewGame());

            Console.WriteLine("Thanks for playing!");
        }

        private static bool NewGame()
        {
            bool invalid = true;
            bool returnValue = false;
            while (invalid)
            {
                Console.WriteLine("Would you like to play another game? [y/n]");
                string playAgain = "";
                playAgain = Console.ReadLine();
                if (playAgain == "y")
                {
                    invalid = false;
                    returnValue = true;
                }
                else if (playAgain == "n")
                {
                    invalid = false;
                    returnValue = false;
                }
                else
                {
                    invalid = true;
                }
            }

            return returnValue;
        }

        private static bool EndOfGame(char[,] board, char player)
        {
            int x = 0;
            int y = 0;
            // Check Rows
            for (y = 0; y < dimension; y++)
            {
                for (x = 0; x < dimension; )
                {
                    if (player == board[x,y])
                    {
                        x++;
                    }
                    else
                    {
                        break;
                    }
                }

                if(x == dimension)
                {
                    return true;
                }
            }

            // Check columns
            for (x = 0; x < dimension; x++)
            {
                for (y = 0; y < dimension; )
                {
                    if (player == board[x,y])
                    {
                        y++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (y == dimension)
                {
                    return true;
                }
            }

            // Check Diagnol


            return false;
        }

       private static string GetSeperatorLine()
        {
            int seperatorLength = (dimension) * 3 + dimension - 1;
            string seperator = "";
            for(int x = 0; x < seperatorLength; x++)
            {
                seperator += "-";
            }

            return seperator;
        }

        private static void PrintBoard(char[,] board)
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
                    Console.Write(board[x,y]);
                    if(x+1 < dimension)
                    {
                        Console.Write(" | ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine(seperator);
        }

        private static char PrintPlayer(int player)
        {
            if (player == 0)
            {
                return 'X';
            }
            else
                return 'O';
        }

        private static void SetMove(char[,] board, Tuple<int, int> move, char player)
        {
            if(board[move.Item1,move.Item2] != emptyCell)
            {
                throw new InvalidMoveException();
            }

            board[move.Item1,move.Item2] = player;
        }

        private static Tuple<int, int> ConvertMove(string move)
        {
            Tuple<int, int> returnValue;
            try
            {
                string[] parts = move.Split(',');
                returnValue = new Tuple<int, int>(int.Parse(parts[0]), int.Parse(parts[1]));
            }
            catch(Exception)
            {
                throw new InvalidMoveException();
            }

            return returnValue;
        }

        private static void ClearBoard(char[,] board)
        {
            for (int x = 0; x < dimension; x++)
            {
                for (int y = 0; y < dimension; y++)
                {
                    board[x,y] = emptyCell;
                }
            }
        }
    }
}
