//
using System;


namespace TicTacToe
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
            string strMove;
            int moveCount;
            Tuple<int, int> move = new Tuple<int, int>(0, 0);

            gameBoard = new char[dimension, dimension];

            Game.ClearBoard(gameBoard);

            do
            {
                Game.ClearBoard(gameBoard);
                // Getting started instructions
                Console.WriteLine("Decide who is player 'X' and who is player 'O' then press any key to start the game.");
                Console.WriteLine("Enter a zero based x and y coordinate separated by a comma for each move. E.g. \"2,1\"");
                Console.ReadLine();
                strMove = "";
                moveCount = -1;

                while (!Game.EndOfGame(gameBoard, Game.PrintPlayer(currentPlayer), move))
                {
                    moveCount++;
                    currentPlayer = moveCount % 2;
                    Game.PrintBoard(gameBoard);
                    Console.Write("Player {0}, make your move: ", Game.PrintPlayer(currentPlayer));
                    strMove = Console.ReadLine();

                    try
                    {
                        move = Game.ConvertMove(strMove);
                        Game.SetMove(gameBoard, move, Game.PrintPlayer(currentPlayer));
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
                Game.PrintBoard(gameBoard);
                Console.WriteLine("Congratultaions player {0}. YOU'VE WON!", Game.PrintPlayer(currentPlayer));

            } while (Game.NewGame());

            Console.WriteLine("Thanks for playing!");
        }
    }
}
