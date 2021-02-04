using System;

namespace ConnectFour
{
    public class WinChecker
    {
        private const int _connect = 4;

        private static bool CheckVertically(int row, int column, TokenType type)
        {
            if (row + _connect - 1 >= Board.Rows)
            {
                return false;
            }

            for (var distance = 0; distance < _connect; distance++)
            {
                if (Board.Grid[row + distance, column] != type)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CheckHorizontally(int row, int column, TokenType type)
        {
            if (column + _connect - 1 >= Board.Columns)
            {
                return false;
            }

            for (var distance = 0; distance < _connect; distance++)
            {
                if (Board.Grid[row, column + distance] != type)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CheckDiagonallyDown(int row, int column, TokenType type)
        {
            if (row + _connect - 1 >= Board.Rows)
            {
                return false;
            }

            if (column + _connect - 1 >= Board.Columns)
            {
                return false;
            }

            for (var distance = 0; distance < _connect; distance++)
            {
                if (Board.Grid[row + distance, column + distance] != type)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CheckDiagonallyUp(int row, int column, TokenType type)
        {
            if (row - _connect - 1 < 0)
            {
                return false;
            }

            if (column + _connect - 1 >= Board.Columns)
            {
                return false;
            }

            for (var distance = 0; distance < _connect; distance++)
            {
                if (Board.Grid[row - distance, column + distance] != type)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool HasWon(TokenType type)
        {
            for (var row = 0; row < Board.Rows; row++)
            {
                for (var column = 0; column < Board.Columns; column++)
                {
                    if (CheckVertically(row, column, type)
                        || CheckHorizontally(row, column, type)
                        || CheckDiagonallyDown(row, column, type)
                        || CheckDiagonallyUp(row, column, type))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void PrintWinConditions()
        {
            if (HasWon(TokenType.Red))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Red won!");
            }
            else if (HasWon(TokenType.Black))
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
    }
}