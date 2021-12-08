namespace XO.Core
{
    public interface IReadOnlyGrid : IEnumerable<Symbol?>
    {
        Symbol? this[Position position] { get; }

        IEnumerable<Position> FreePositions { get; }

        bool IsFilled();

        Symbol?[] GetRow(int index);

        Symbol?[] GetColumn(int index);

        IEnumerable<Symbol?> GetDiagonal(Position position);

        IEnumerable<Symbol?> GetAntidiagonal(Position position);
    }
}
