using System.Globalization;
using Spectre.Console;
using XO.Core;
using XO.Core.Players;
using XO.Resources;
using XO.SystemExtensions.Exceptions;

namespace XO.ConsoleUI.Internal
{
    internal class GameConsole
    {
        public GameConsole(IReadOnlyGame game)
        {
            this.game = game;
            gridPrinter = new GridPrinter(game.Grid);
        }

        public static void WriteWelcome()
        {
            WriteLine(Messages.Welcome);
            WriteLine();
        }

        public IEnumerable<IPlayer> RequestPlayers()
        {
            var playerKinds = Enum.GetValues<PlayerKind>();

            yield return PromptForPlayer(playerKinds, playerIndex: 1);
            yield return PromptForPlayer(playerKinds, playerIndex: 2);
        }

        public void WriteGrid()
        {
            WriteLine(gridPrinter.GetGrid());
            WriteLine();
        }

        public void WriteTurn()
            => WriteLine(
                Format(Messages.PlayerTurn, game.CurrentSymbol));

        public void WriteState()
            => WriteLine(
                MessageMap.GetFor(game.State));

        public void WriteChosenPosition(Position choosenPosition)
        {
            var symbol = game.Grid[choosenPosition];
            WriteLine(
                Format(Messages.PlayerMarks, symbol, choosenPosition));
        }

        private Position PromptForPosition()
            => PromptForSelection(
                title: Messages.SelectCell,
                choises: game.Grid.FreePositions
                    .OrderBy(p => p.Column)
                    .ThenBy(p => p.Row));

        private IPlayer PromptForPlayer(IEnumerable<PlayerKind> playerKinds, int playerIndex)
        {
            var playerKind = PromptForSelection(
                title: Format(Messages.SelectPlayerType, playerIndex),
                choises: playerKinds);

            return CreatePlayer(playerKind);
        }

        private IPlayer CreatePlayer(PlayerKind playerKind)
            => playerKind switch
            {
                PlayerKind.Human => new HumanPlayer(choosePosition: () => PromptForPosition()),
                PlayerKind.RandomizingComputer => new RandomizingComputerPlayer(game),
                _ => throw new UnhandledEnumValueException(playerKind),
            };

        private static T PromptForSelection<T>(string title, IEnumerable<T> choises)
            where T : notnull
            => AnsiConsole.Prompt(
                new SelectionPrompt<T>()
                    .Title(title)
                    .AddChoices(choises));

        private static string Format(string format, params object?[] args)
            => string.Format(CultureInfo.CurrentCulture, format, args);

        private static void WriteLine(string text)
            => Console.WriteLine(text);

        private static void WriteLine()
            => Console.WriteLine();

        private readonly IReadOnlyGame game;
        private readonly GridPrinter gridPrinter;
    }
}
