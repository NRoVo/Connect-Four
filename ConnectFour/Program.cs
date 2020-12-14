using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            var currentColumn = 3;
            var currentType = TokenType.Red;
            while (!board.HasWon(TokenType.Red) && !board.HasWon(TokenType.Black) && !board.IsFull())
            {
                Console.Clear();
                DrawHeader(board, currentColumn, currentType);
                board.DrawBoard();
                var key = Console.ReadKey();
                if (key.KeyChar == '1')
                {
                    currentColumn = 0;
                }
                else if (key.KeyChar == '2')
                {
                    currentColumn = 1;
                }
                else if (key.KeyChar == '3')
                {
                    currentColumn = 2;
                }
                else if (key.KeyChar == '4')
                {
                    currentColumn = 3;
                }
                else if (key.KeyChar == '5')
                {
                    currentColumn = 4;
                }
                else if (key.KeyChar == '6')
                {
                    currentColumn = 5;
                }
                else if (key.KeyChar == '7')
                {
                    currentColumn = 6;
                }
                else if (key.Key == ConsoleKey.LeftArrow && currentColumn > 0)
                {
                    currentColumn--;
                }
                else if (key.Key == ConsoleKey.RightArrow && currentColumn < 6)
                {
                    currentColumn++;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    if (board.CanAdd(currentColumn))
                    {
                        board.Add(currentColumn, currentType);
                        if (currentType == TokenType.Red)
                        {
                            currentType = TokenType.Black;
                        }
                        else
                        {
                            currentType = TokenType.Red;
                        }
                    }
                }
            }

            Console.Clear();
            DrawHeader(board, currentColumn, currentType);
            board.DrawBoard();
            PrintWinConditions(board);
            Console.ReadKey();
        }

        private static void PrintWinConditions(Board board)
        {
            if (board.HasWon(TokenType.Red))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Red won!");
            }
            else if (board.HasWon(TokenType.Black))
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Black won!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("The game was a draw!");
            }
        }

        private static void DrawHeader(Board board, int currentColumn, TokenType currentType)
        {
            var symbol = board.CanAdd(currentColumn) ? "O" : "x";
            Console.ForegroundColor = currentType == TokenType.Red ? ConsoleColor.Red : ConsoleColor.DarkGray;
            Console.WriteLine("   {0} {1} {2} {3} {4} {5} {6}",
                currentColumn == 0 ? symbol : " ",
                currentColumn == 1 ? symbol : " ",
                currentColumn == 2 ? symbol : " ",
                currentColumn == 3 ? symbol : " ",
                currentColumn == 4 ? symbol : " ",
                currentColumn == 5 ? symbol : " ",
                currentColumn == 6 ? symbol : " ");
        }
    }
}