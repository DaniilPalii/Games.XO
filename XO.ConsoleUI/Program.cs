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

while (game.State is GameState.Pending)
{
    players.MoveNext();
    console.WriteTurn();
    game.Mark(
        players.Current.ChoosePosition());
    Console.SetCursorPosition(0, 0);
    console.WriteGrid();
    Thread.Sleep(500);
}

console.WriteState();
