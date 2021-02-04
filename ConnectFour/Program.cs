using System;

namespace ConnectFour
{
    internal static class Program
    {
        private static void Main()
        {
            new Board();
            var winChecker = new WinChecker();
            const TokenType currentType = TokenType.Red;
            var position = new Position();

            var currentColumn = position.SwitchPosition();

            Console.Clear();
            Renderer.DrawHeader(currentColumn, currentType);
            Renderer.DrawBoard();
            winChecker.PrintWinConditions();
            Console.ReadKey();
        }
    }
}