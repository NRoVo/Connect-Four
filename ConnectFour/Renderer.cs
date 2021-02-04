using System;

namespace ConnectFour
{
    public class Renderer
    {
        public static void DrawBoard()
        {
            for (var row = 0; row < Board.Rows; row++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("■■ ");
                for (var column = 0; column < Board.Columns; column++)
                {
                    TokenType type = Board.Grid[row, column];
                    switch (type)
                    {
                        case TokenType.Empty:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(". ");
                            break;
                        case TokenType.Red:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("O ");
                            break;
                        case TokenType.Black:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("O ");
                            break;
                    }
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("■■");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■");
        }

        public static void DrawHeader(int currentColumn, TokenType currentType)
        {
            var symbol = Board.CanAdd(currentColumn) ? "O" : "x";
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