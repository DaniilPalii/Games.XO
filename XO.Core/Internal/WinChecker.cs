using XO.SystemExtensions;

namespace XO.Core.Internal
{
    internal class WinChecker
    {
        public WinChecker(IReadOnlyGrid grid)
            => this.grid = grid;

        public bool DoesWin(Position lastMarkedPosition)
            => HasThreeInRow(lastMarkedPosition.Row)
                || HasThreeInColumn(lastMarkedPosition.Column)
                || HasThreeInDiagonal(lastMarkedPosition)
                || HasThreeInAntidiagonal(lastMarkedPosition);
        private bool HasThreeInRow(int index)
            => grid.GetRow(index)
                .AreEqual();

        private bool HasThreeInColumn(int index)
            => grid.GetColumn(index)
                .AreEqual();

        private bool HasThreeInDiagonal(Position position)
        {
            var marks = grid.GetDiagonal(position)
                .ToList();

            return marks.Count == 3
                && marks.AreEqual();
        }

        private bool HasThreeInAntidiagonal(Position position)
        {
            var marks = grid.GetAntidiagonal(position)
                .ToList();

            return marks.Count == 3
                && marks.AreEqual();
        }

        private readonly IReadOnlyGrid grid;
    }
}
