using System.Collections;
using System.Diagnostics.CodeAnalysis;
using XO.SystemExtensions;

namespace XO.Core.Components
{
    public class Grid : IReadOnlyGrid
    {
        public Grid()
            => marks = new Symbol?[Size, Size];

        public Symbol? this[Position position]
        {
            get => marks[position.Row, position.Column];
            set => marks[position.Row, position.Column] = value;
        }

        public bool IsFilled()
            => GetCells()
                .All(c => !c.Empty);

        IEnumerable<ReadOnlyLine> IReadOnlyGrid.GetLines()
            => GetLines();

        public IEnumerable<Line> GetLines()
            => GetRows()
                .Concat(GetColumns())
                .Concat(GetDiagonals());

        IEnumerable<ReadOnlyLine> IReadOnlyGrid.GetLines(Position position)
            => GetLines(position);

        public IEnumerable<Line> GetLines(Position position)
        {
            yield return GetRow(position.Row);
            yield return GetColumn(position.Column);

            if (TryGetDiagonal(position, out var diagonal))
                yield return diagonal;

            if (TryGetAntidiagonal(position, out var antidiagonal))
                yield return antidiagonal;
        }

        IEnumerable<ReadOnlyLine> IReadOnlyGrid.GetRows()
            => GetRows();

        public IEnumerable<Line> GetRows()
        {
            for (var i = 0; i < Size; i++)
                yield return GetRow(i);
        }

        ReadOnlyLine IReadOnlyGrid.GetRow(int index)
            => GetRow(index);

        public Line GetRow(int index)
        {
            var cells = new List<Cell>(Size);

            for (var columnIndex = 0; columnIndex < Size; columnIndex++)
                cells.Add(
                    GetCell(rowIndex: index, columnIndex));

            return new Line(cells);

        }

        IEnumerable<ReadOnlyLine> IReadOnlyGrid.GetColumns()
            => GetColumns();

        public IEnumerable<Line> GetColumns()
        {
            for (var i = 0; i < Size; i++)
                yield return GetColumn(i);
        }

        ReadOnlyLine IReadOnlyGrid.GetColumn(int index)
            => GetColumn(index);

        public Line GetColumn(int index)
        {
            var cells = new List<Cell>(Size);

            for (var rowIndex = 0; rowIndex < Size; rowIndex++)
                cells.Add(
                    GetCell(rowIndex, columnIndex: index));

            return new Line(cells);
        }

        /// <summary> Get diagonal (from top left end to bottom right end) and antidiagonal (from top right end to bottom left end). </summary>
        IEnumerable<ReadOnlyLine> IReadOnlyGrid.GetDiagonals()
            => GetDiagonals();

        /// <summary> Get diagonal (from top left end to bottom right end) and antidiagonal (from top right end to bottom left end). </summary>
        public IEnumerable<Line> GetDiagonals()
        {
            yield return GetDiagonal();
            yield return GetAntidiagonal();
        }

        /// <summary> Get diagonal from top left end to bottom right end if given position belongs to it. </summary>
        bool IReadOnlyGrid.TryGetDiagonal(Position position, [MaybeNullWhen(false)] out ReadOnlyLine diagonal)
        {
            diagonal = GetDiagonal();

            if (diagonal.Positions.Contains(position))
                return true;

            diagonal = null;
            return false;
        }

        /// <summary> Get diagonal from top left end to bottom right end if given position belongs to it. </summary>
        public bool TryGetDiagonal(Position position, [MaybeNullWhen(false)] out Line diagonal)
        {
            diagonal = GetDiagonal();

            if (diagonal.Positions.Contains(position))
                return true;

            diagonal = null;
            return false;
        }

        /// <summary> Get diagonal from top left end to bottom right end. </summary>
        ReadOnlyLine IReadOnlyGrid.GetDiagonal()
            => GetDiagonal();

        /// <summary> Get diagonal from top left end to bottom right end. </summary>
        public Line GetDiagonal()
        {
            var cells = new List<Cell>(Size);

            for (var position = new Position(0, 0);
                position.Row < Size && position.Column < Size;
                position = new Position(position.Row + 1, position.Column + 1))
                cells.Add(
                    GetCell(position));

            return new Line(cells);
        }

        /// <summary> Get diagonal from top right end to bottom left end if given position belongs to it. </summary>
        bool IReadOnlyGrid.TryGetAntidiagonal(Position position, [MaybeNullWhen(false)] out ReadOnlyLine antidiagonal)
        {
            antidiagonal = GetDiagonal();

            if (antidiagonal.Positions.Contains(position))
                return true;

            antidiagonal = null;
            return false;
        }

        /// <summary> Get diagonal from top right end to bottom left end if given position belongs to it. </summary>
        public bool TryGetAntidiagonal(Position position, [MaybeNullWhen(false)] out Line antidiagonal)
        {
            antidiagonal = GetDiagonal();

            if (antidiagonal.Positions.Contains(position))
                return true;

            antidiagonal = null;
            return false;
        }

        /// <summary> Get diagonal from top right end to bottom left end. </summary>
        ReadOnlyLine IReadOnlyGrid.GetAntidiagonal()
            => GetAntidiagonal();

        /// <summary> Get diagonal from top right end to bottom left end. </summary>
        public Line GetAntidiagonal()
        {
            var cells = new List<Cell>(Size);

            for (var position = new Position(0, LastIndex);
                position.Row < Size && position.Column >= 0;
                position = new Position(position.Row + 1, position.Column - 1))
                cells.Add(
                    GetCell(position));

            return new Line(cells);
        }

        ReadOnlyCell IReadOnlyGrid.GetCenter()
            => GetCenter();

        public Cell GetCenter()
            => GetCell(CentralIndex, CentralIndex);

        IEnumerable<ReadOnlyCell> IReadOnlyGrid.GetCorners()
            => GetCorners();

        public IEnumerable<Cell> GetCorners()
        {
            yield return GetCell(0, 0);
            yield return GetCell(0, LastIndex);
            yield return GetCell(LastIndex, 0);
            yield return GetCell(LastIndex, LastIndex);
        }

        IEnumerable<ReadOnlyCell> IReadOnlyGrid.GetCells()
            => GetCells();

        public IEnumerable<Cell> GetCells()
            => GetPositions()
                .Select(p => GetCell(p));

        ReadOnlyCell IReadOnlyGrid.GetCell(Position position)
            => GetCell(position);

        public Cell GetCell(Position position)
            => new(this, position);

        ReadOnlyCell IReadOnlyGrid.GetCell(int rowIndex, int columnIndex)
            => GetCell(rowIndex, columnIndex);

        public Cell GetCell(int rowIndex, int columnIndex)
            => new(this, rowIndex, columnIndex);

        public IEnumerable<Position> GetFreePositions()
            => GetCells()
                .Where(c => c.Empty)
                .Select(c => c.Position);

        public IEnumerator<Symbol?> GetEnumerator()
            => marks.ToEnumerable()
                .GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => marks.GetEnumerator();

        public static IEnumerable<Position> GetPositions()
        {
            for (var rowIndex = 0; rowIndex < Size; rowIndex++)
                for (var columnIndex = 0; columnIndex < Size; columnIndex++)
                    yield return new Position(rowIndex, columnIndex);
        }

        public const int Size = 3;
        public const int LastIndex = Size - 1;
        public const int CentralIndex = LastIndex / 2;

        private readonly Symbol?[,] marks;
    }
}
