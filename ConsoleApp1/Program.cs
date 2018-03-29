using System;

namespace ConsoleApp1
{
    class Program
    {
        static char[][] board;
        private static bool continueplay = true;
        private static int currentPlayer;
        private static readonly char emptyCell = '\0';

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int dimension = 3;

            if (args.Length != 0)
            {
                dimension = int.Parse(args[0]);
            }

            SetupBoard(dimension);

            PlayGame();
        }

        private static void PlayGame()
        {
            Console.Write("Decide who is player 'X' and who is player 'O' then press any key to start the game.");
            Console.ReadLine();
            string move = "";
            while (continueplay)
            {
                string result = "";
                PrintBoard();
                Console.Write("Player %1, make your move: ", currentPlayer);
                move = Console.ReadLine();

                VerifyMove(move);
                result = CheckBopardForWinner();
                SetMove(move);

                if (result != "")
                {
                    Console.WriteLine("Congratultaions %1. YOU WON!", result);
                    if (PlayAgain())
                    {
                        ClearBoard();
                    }
                    else
                    {
                        continueplay = false;
                    }
                }
            }

            Console.WriteLine("Thanks for playing!");
        }

        private static bool PlayAgain()
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

        private static string CheckBopardForWinner()
        {
            throw new NotImplementedException();
        }

        private static void PrintBoard()
        {
            throw new NotImplementedException();
        }

        private static void SetMove(string move)
        {
            throw new NotImplementedException();
        }

        private static void VerifyMove(string move)
        {
            throw new NotImplementedException();
        }

        private static void SetupBoard(int dimension)
        {
            board = new char[dimension][];
            for (int x = 0; x < board.Length; x++)
            {
                board[x] = new char[dimension];
            }

            ClearBoard();
            //foreach( char[] y in Board)
            //{
            //    y = new char[dimension];
            //}
        }

        private static void ClearBoard()
        {
            for (int x = 0; x < board.Length; x++)
            {
                for (int y = 0; y < board[x].Length; y++)
                {
                    board[x][y] = emptyCell;
                }
            }
        }
    }
}
