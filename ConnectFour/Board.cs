namespace ConnectFour
{
    public class Board
    {
        public static int Rows => 6;
        public static int Columns => 7;
        public static TokenType[,] Grid;

        public Board()
        {
            Grid = new TokenType[Rows, Columns];
            PopulateEmptyGrid();
        }

        private static void PopulateEmptyGrid()
        {
            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    Grid[row, column] = TokenType.Empty;
                }
            }
        }

        public static bool CanAdd(int column) => Grid[0, column] == TokenType.Empty;

        public static bool IsFull()
        {
            for (var column = 0; column < Columns; column++)
            {
                if (CanAdd(column))
                {
                    return false;
                }
            }

            return true;
        }

        public static void Add(int column, TokenType type)
        {
            if (!CanAdd(column))
            {
                return;
            }

            var currenntRow = 0;
            while (currenntRow < Rows - 1 && Grid[currenntRow + 1, column] == TokenType.Empty)
            {
                currenntRow++;
            }

            Grid[currenntRow, column] = type;
        }
    }
}