using XO.Core.Internal;

namespace XO.Core
{
    public class Game : IReadOnlyGame
    {
        public Game()
        {
            RandomizeCurrentSymbol();
            winChecker = new(Grid);
        }

        public IReadOnlyGrid Grid => grid;

        public Symbol CurrentSymbol { get; private set; }

        public GameState State { get; private set; }

        public void Mark(Position position)
        {
            if (State is not GameState.Pending
                || grid[position] is not null)
                throw new InvalidOperationException("Given position isn't empty.");

            grid[position] = CurrentSymbol;
            lastMarkedPosition = position;
            FinishTurn();
        }

        private void FinishTurn()
        {
            if (IsWin())
                State = CurrentSymbol is Symbol.X
                    ? GameState.XWin
                    : GameState.OWin;
            else if (Grid.IsFilled())
                State = GameState.Draw;
            else
                SwitchCurrentSymbol();
        }

        private void RandomizeCurrentSymbol()
            => CurrentSymbol = random.Next(0, 1) is 1
                ? Symbol.X
                : Symbol.O;

        private Symbol SwitchCurrentSymbol()
            => CurrentSymbol = CurrentSymbol is Symbol.X
                ? Symbol.O
                : Symbol.X;

        private bool IsWin()
            => winChecker.DoesWin(lastMarkedPosition);

        private readonly Grid grid = new();
        private readonly Random random = new();
        private readonly WinChecker winChecker;

        private Position lastMarkedPosition;
    }
}
