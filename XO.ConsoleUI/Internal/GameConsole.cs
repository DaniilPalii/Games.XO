using Spectre.Console;
using XO.Core;

namespace XO.ConsoleUI.Internal
{
    internal class GameConsole
    {
        public GameConsole(Game game)
        {
            this.game = game;
            this.gridPrinter = new GridPrinter(game.Grid);
        }

        public void WriteWelcome()
            => Console.WriteLine("Welcome to Tic-tac-toe game!\n");

        public void WriteGrid()
        {
            Console.WriteLine(this.gridPrinter.GetGrid());
            Console.WriteLine();
        }

        public void WriteTurn()
            => Console.WriteLine($"Player {this.game.CurrentSymbol} turn.");

        public Position PromtPosition()
            => AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select cell:")
                    .AddChoices(
                        this.gridPrinter.GetFreePositions()))
                .ToPosition();

        public void WriteState()
        {
            var stateMessage = game.State switch
            {
                GameState.Pending => "Game is pending.",
                GameState.Draw => "It's a draw.",
                GameState.XWin => "Player X win!",
                GameState.OWin => "Player O win!",
                _ => throw new ArgumentException(nameof(game.State)),
            };
            Console.WriteLine(stateMessage);
        }

        public void Clear()
            => Console.Clear();

        private readonly Game game;
        private readonly GridPrinter gridPrinter;
    }
}
