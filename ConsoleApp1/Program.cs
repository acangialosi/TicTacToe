using System;

namespace ConsoleApp1
{
    class Program
    {
        static char[][] board;
        private static bool continueplay = true;
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
            string move = "";
            while (continueplay)
            {
                move = Console.ReadLine();

            }
        }

        private static void SetupBoard(int dimension)
        {
            board = new char[dimension][];
            for(int x = 0; x<board.Length; x++)
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
