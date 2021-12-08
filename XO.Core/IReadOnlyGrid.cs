namespace XO.Core
{
    public interface IReadOnlyGrid : IEnumerable<Symbol?>
    {
        Symbol? this[Position position] { get; }

        IEnumerable<Position> FreePositions { get; }

        bool IsFilled();

        IEnumerable<IEnumerable<ICell>> GetLines();

        IEnumerable<IEnumerable<ICell>> GetLines(Position position);

        IEnumerable<IEnumerable<ICell>> GetRows();

        IEnumerable<ICell> GetRow(int index);

        IEnumerable<IEnumerable<ICell>> GetColumns();

        IEnumerable<ICell> GetColumn(int index);

        IEnumerable<IEnumerable<ICell>> GetDiagonals();

        bool TryGetDiagonal(Position position, out IEnumerable<ICell> diagonal);

        IEnumerable<ICell> GetDiagonal();

        bool TryGetAntidiagonal(Position position, out IEnumerable<ICell> antidiagonal);

        IEnumerable<ICell> GetAntidiagonal();
    }
}
