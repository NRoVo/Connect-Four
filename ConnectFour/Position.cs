using System;

namespace ConnectFour
{
    public class Position
    {
        private int _currentColumn = 3;
        private TokenType _currentType = TokenType.Red;

        public int SwitchPosition()
        {
            while (!WinChecker.HasWon(TokenType.Red) && !WinChecker.HasWon(TokenType.Black) && !Board.IsFull())
            {
                Console.Clear();
                Renderer.DrawHeader(_currentColumn, _currentType);
                Renderer.DrawBoard();
                var key = Console.ReadKey();
                if (key.Key != ConsoleKey.Enter)
                {
                    _currentColumn = key switch
                    {
                        {KeyChar: var k} when k >= '1' && k <= '7'           => k - '0' - 1,
                        {Key: ConsoleKey.LeftArrow} when _currentColumn > 0  => _currentColumn - 1,
                        {Key: ConsoleKey.RightArrow} when _currentColumn < 6 => _currentColumn + 1,
                        var _                                                => _currentColumn,
                    };
                }
                else
                {
                    if (Board.CanAdd(_currentColumn))
                    {
                        Board.Add(_currentColumn, _currentType);
                        _currentType = _currentType == TokenType.Red ? TokenType.Black : TokenType.Red;
                    }
                }
            }

            return _currentColumn;
        }
    }
}