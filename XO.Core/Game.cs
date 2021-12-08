using XO.Core.Internal;

namespace XO.Core
{
    public class Game
    {
        public Game()
        {
            this.RandomizeCurrentSymbol();
            this.winChecker = new(this.Grid);
        }

        public IReadOnlyGrid Grid
            => this.grid;

        public Symbol CurrentSymbol { get; set; }

        public GameState State { get; set; }

        public void Mark(Position position)
        {
            if (this.State is not GameState.Pending
                || this.grid[position] is not null)
                return;

            this.grid[position] = this.CurrentSymbol;
            this.lastMarkedPosition = position;
            this.FinishTurn();
        }

        private void FinishTurn()
        {
            if (this.IsWin())
                this.State = this.CurrentSymbol is Symbol.X
                    ? GameState.XWin
                    : GameState.OWin;
            else if (this.Grid.All(cell => cell is not null))
                this.State = GameState.Draw;
            else
                this.SwitchCurrentSymbol();
        }
        private void RandomizeCurrentSymbol()
            => this.CurrentSymbol = this.random.Next(0, 1) is 1
                ? Symbol.X
                : Symbol.O;

        private Symbol SwitchCurrentSymbol()
            => this.CurrentSymbol = this.CurrentSymbol is Symbol.X
                ? Symbol.O
                : Symbol.X;

        private bool IsWin()
            => this.winChecker.DoesWin(this.lastMarkedPosition);

        private readonly Grid grid = new();
        private readonly Random random = new();
        private readonly WinChecker winChecker;

        private Position lastMarkedPosition;
    }
}
