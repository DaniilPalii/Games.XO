using XO.Extensions;

namespace XO.Core.Internal
{
    internal class WinChecker
    {
        public WinChecker(IReadOnlyGrid grid)
            => this.grid = grid;

        public bool DoesWin(Position lastMarkedPosition)
            => this.HasThreeInRow(lastMarkedPosition.Row)
                || this.HasThreeInColumn(lastMarkedPosition.Column)
                || this.HasThreeInDiagonal(lastMarkedPosition)
                || this.HasThreeInAntidiagonal(lastMarkedPosition);
        private bool HasThreeInRow(int index)
            => this.grid.GetRow(index)
                .AreEqual();

        private bool HasThreeInColumn(int index)
            => this.grid.GetColumn(index)
                .AreEqual();

        private bool HasThreeInDiagonal(Position position)
        {
            var marks = this.grid.GetDiagonal(position)
                .ToList();

            return marks.Count == 3
                && marks.AreEqual();
        }

        private bool HasThreeInAntidiagonal(Position position)
        {
            var marks = this.grid.GetAntidiagonal(position)
                .ToList();

            return marks.Count == 3
                && marks.AreEqual();
        }

        private readonly IReadOnlyGrid grid;
    }
}
