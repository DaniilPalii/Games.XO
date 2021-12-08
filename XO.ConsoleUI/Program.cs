using XO.ConsoleUI.Internal;
using XO.Core;
using XO.SystemExtensions;

Console.Clear();
GameConsole.WriteWelcome();

var game = new Game();
var gameConsole = new GameConsole(game);

var players = gameConsole.RequestPlayers()
    .ToList()
    .RepeatEndless()
    .GetEnumerator();
Console.Clear();
gameConsole.WriteGrid();

Position choosenPosition;

while (game.State is GameState.Pending)
{
    players.MoveNext();
    gameConsole.WriteTurn();
    choosenPosition = players.Current.ChoosePosition();
    game.Mark(choosenPosition);

    Console.SetCursorPosition(0, 0);
    gameConsole.WriteGrid();
    gameConsole.WriteChosenPosition(choosenPosition);
}

gameConsole.WriteState();
