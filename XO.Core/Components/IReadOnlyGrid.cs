using System.Diagnostics.CodeAnalysis;

namespace XO.Core.Components
{
    public interface IReadOnlyGrid : IEnumerable<Symbol?>
    {
        Symbol? this[Position position] { get; }

        bool IsFilled();

        IEnumerable<ReadOnlyLine> GetLines();

        IEnumerable<ReadOnlyLine> GetLines(Position position);

        IEnumerable<ReadOnlyLine> GetRows();

        ReadOnlyLine GetRow(int index);

        IEnumerable<ReadOnlyLine> GetColumns();

        ReadOnlyLine GetColumn(int index);

        IEnumerable<ReadOnlyLine> GetDiagonals();

        bool TryGetDiagonal(Position position, [MaybeNullWhen(false)] out ReadOnlyLine diagonal);

        ReadOnlyLine GetDiagonal();

        bool TryGetAntidiagonal(Position position, [MaybeNullWhen(false)] out ReadOnlyLine antidiagonal);

        ReadOnlyLine GetAntidiagonal();

        ReadOnlyCell GetCenter();

        IEnumerable<ReadOnlyCell> GetCorners();

        IEnumerable<ReadOnlyCell> GetCells();

        ReadOnlyCell GetCell(Position position);

        ReadOnlyCell GetCell(int rowIndex, int columnIndex);

        IEnumerable<Position> GetFreePositions();
    }
}
