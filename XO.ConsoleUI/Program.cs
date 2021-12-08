using XO.ConsoleUI.Internal;
using XO.Core;
using XO.SystemExtensions;

Console.Clear();
GameConsole.WriteWelcome();

var game = new Game();
var console = new GameConsole(game);

var players = console.RequestPlayers()
    .ToList()
    .RepeatEndless()
    .GetEnumerator();
Console.Clear();
console.WriteGrid();

Position choosenPosition;

while (game.State is GameState.Pending)
{
    players.MoveNext();
    console.WriteTurn();
    choosenPosition = players.Current.ChoosePosition();
    game.Mark(choosenPosition);

    Console.SetCursorPosition(0, 0);
    console.WriteGrid();
    console.WriteChosenPosition(choosenPosition);
}

console.WriteState();
