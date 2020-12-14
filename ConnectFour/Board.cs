using System;

namespace ConnectFour
{
    public class Board
    {
        private const int connect = 4;
        private const int rows = 6;
        private const int columns = 7;
        private readonly TokenType[,] grid;

        public Board()
        {
            grid = new TokenType[rows, columns];
            PopulateEmptyGrid();
        }

        private void PopulateEmptyGrid()
        {
            for (var row = 0; row < rows; row++)
            {
                for (var column = 0; column < columns; column++)
                {
                    grid[row, column] = TokenType.Empty;
                }
            }
        }

        private bool CheckVertically(int row, int column, TokenType type)
        {
            if (row + connect >= rows)
            {
                return false;
            }

            for (var distance = 0; distance < connect; distance++)
            {
                if (grid[row + distance, column] != type)
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckHorizontally(int row, int column, TokenType type)
        {
            if (column + connect >= columns)
            {
                return false;
            }

            for (var distance = 0; distance < connect; distance++)
            {
                if (grid[row, column + distance] != type)
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckDiagonallyDown(int row, int column, TokenType type)
        {
            if (row + connect >= rows)
            {
                return false;
            }

            if (column + connect >= columns)
            {
                return false;
            }

            for (var distance = 0; distance < connect; distance++)
            {
                if (grid[row + distance, column + distance] != type)
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckDiagonallyUp(int row, int column, TokenType type)
        {
            if (row - connect < 0)
            {
                return false;
            }

            if (column + connect >= columns)
            {
                return false;
            }

            for (var distance = 0; distance < connect; distance++)
            {
                if (grid[row - distance, column + distance] != type)
                {
                    return false;
                }
            }

            return true;
        }

        public bool HasWon(TokenType type)
        {
            for (var row = 0; row < rows; row++)
            {
                for (var column = 0; column < columns; column++)
                {
                    if (CheckVertically(row, column, type))
                    {
                        return true;
                    }

                    if (CheckHorizontally(row, column, type))
                    {
                        return true;
                    }

                    if (CheckDiagonallyDown(row, column, type))
                    {
                        return true;
                    }

                    if (CheckDiagonallyUp(row, column, type))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool CanAdd(int column) => grid[0, column] == TokenType.Empty;

        public bool IsFull()
        {
            for (var column = 0; column < columns; column++)
            {
                if (CanAdd(column))
                {
                    return false;
                }
            }

            return true;
        }

        public void Add(int column, TokenType type)
        {
            if (!CanAdd(column))
            {
                return;
            }

            var currenntRow = 0;
            while (currenntRow < rows - 1 && grid[currenntRow + 1, column] == TokenType.Empty)
            {
                currenntRow++;
            }

            grid[currenntRow, column] = type;
        }

        public void DrawBoard()
        {
            for (var row = 0; row < rows; row++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("■■ ");
                for (var column = 0; column < columns; column++)
                {
                    TokenType type = grid[row, column];
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
    }
}