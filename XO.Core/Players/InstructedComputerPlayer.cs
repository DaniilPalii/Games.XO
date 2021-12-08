using System.Diagnostics.CodeAnalysis;
using XO.Core.Components;
using XO.SystemExtensions;

namespace XO.Core.Players
{
    public class InstructedComputerPlayer : IPlayer
    {
        public InstructedComputerPlayer(IReadOnlyGame game)
            => this.game = game;

        public Position ChoosePosition()
            => ChoosePosition(
                TryMarkThirdInLine,
                TryBlockOponnentThirdInLine,
                TryFork,
                //TryMarkSecondInLine,
                TryMarkCenter,
                TryMarkCorner,
                TryMarkAnyPosition);

        private bool TryMarkThirdInLine([NotNullWhen(true)] out Position? choise)
        {
            var lineWithTwoSymbols = Grid.GetLines()
                .FirstOrDefault(l => l.HasTwo(Symbol) && l.HasSingleEmpty());

            if (lineWithTwoSymbols == null)
            {
                choise = null;
                return false;
            }

            choise = lineWithTwoSymbols.Single(c => c.Empty).Position;
            return true;
        }

        private bool TryBlockOponnentThirdInLine([NotNullWhen(true)] out Position? choise)
        {
            var lineWithTwoOtherSymbols = Grid.GetLines()
                .FirstOrDefault(l => l.HasTwo(Symbol.Next()) && l.HasSingleEmpty());

            if (lineWithTwoOtherSymbols == null)
            {
                choise = null;
                return false;
            }

            choise = lineWithTwoOtherSymbols.Single(c => c.Empty).Position;
            return true;
        }

        private bool TryFork([NotNullWhen(true)] out Position? choise)
        {
            if (Grid.Count(s => s == Symbol) < 2)
            {
                choise = null;
                return false;
            }

            var emptyCells = Grid.GetCells()
                .Where(c => c.Empty);
            var cell = emptyCells.FirstOrDefault(
                c => Grid.GetLines(c.Position)
                    .Count(l => l.HasTwoEmpty() && l.HasSingle(Symbol)) == 2);

            if (cell == null)
            {
                choise = null;
                return false;
            }

            choise = cell.Position;
            return true;
        }

        //private bool TryMarkSecondInLine([NotNullWhen(true)] out Position? choise)
        //{
        //    var lineWithSingleSymbol = Grid.GetLines()
        //        .FirstOrDefault(
        //            l => l.HasSingle(Symbol)
        //                && l.HasTwoEmpty());

        //    if (lineWithSingleSymbol == null)
        //    {
        //        choise = null;
        //        return false;
        //    }

        //    choise = lineWithSingleSymbol.Where(c => c.Empty)
        //        .TopPriority();

        //    return true;
        //}

        private bool TryMarkCenter([NotNullWhen(true)] out Position? choise)
        {
            var center = Grid.GetCenter();

            if (center.Empty)
            {
                choise = center.Position;
                return true;
            }

            choise = null;
            return false;
        }

        private bool TryMarkCorner([NotNullWhen(true)] out Position? choise)
        {
            if (Grid.GetCorners()
                .TryGet(c => c.Empty, out var emptyCorner))
            {
                choise = emptyCorner.Position;
                return true;
            }

            choise = null;
            return false;
        }

        private bool TryMarkAnyPosition([NotNullWhen(true)] out Position? choise)
        {
            if (Grid.GetCells()
                .TryGet(c => c.Empty, out var emptyCell))
            {
                choise = emptyCell.Position;
                return true;
            }

            choise = null;
            return false;
        }

        private Symbol Symbol
            => game.CurrentSymbol;

        private bool IsOther(Symbol symbol)
            => symbol != game.CurrentSymbol;

        private IReadOnlyGrid Grid
            => game.Grid;

        private static Position ChoosePosition(params TryChoosePositionApproach[] approaches)
        {
            foreach (var tryChoosePosition in approaches)
                if (tryChoosePosition(out var choise))
                    return choise.Value;

            throw new InvalidOperationException();
        }

        //private static ReadOnlyCell TopPriority(IEnumerable<ReadOnlyCell> cells)
        //{
        //    if (cells.TryGet(c => c.IsCenter())
        //}

        private readonly IReadOnlyGame game;

        private delegate bool TryChoosePositionApproach([NotNullWhen(true)] out Position? choise);
    }
}
