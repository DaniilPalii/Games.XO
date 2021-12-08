using XO.ConsoleUI.Internal;
using XO.Core;

var game = new Game();
var console = new GameConsole(game);

console.Clear();
console.WriteWelcome();

while (game.State is GameState.Pending)
{
    console.WriteGrid();
    console.WriteTurn();
    game.Mark(
        console.PromtPosition());
    console.Clear();
}

console.WriteGrid();
console.WriteState();
