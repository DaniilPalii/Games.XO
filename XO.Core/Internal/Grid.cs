using System.Collections;
using XO.SystemExtensions;

namespace XO.Core.Internal
{
    internal class Grid : IReadOnlyGrid
    {
        public Grid()
            => marks = new Symbol?[Width, Height];

        public Symbol? this[Position position]
        {
            get => marks[position.Row, position.Column];
            set => marks[position.Row, position.Column] = value;
        }

        public IEnumerable<Position> FreePositions
            => Cells.Where(c => c.Empty)
                .Select(c => c.Position);

        public IEnumerable<ICell> Cells
            => Positions.Select(p => new Cell(this, p));

        public static IEnumerable<Position> Positions
        {
            get
            {
                for (var rowIndex = 0; rowIndex < Height; rowIndex++)
                    for (var columnIndex = 0; columnIndex < Width; columnIndex++)
                        yield return new Position(rowIndex, columnIndex);
            }
        }

        public bool IsFilled()
            => Cells.All(c => !c.Empty);

        public IEnumerable<IEnumerable<ICell>> GetLines()
            => GetRows()
                .Concat(GetColumns())
                .Concat(GetDiagonals());

        public IEnumerable<IEnumerable<ICell>> GetLines(Position position)
        {
            yield return GetRow(position.Row);
            yield return GetColumn(position.Column);

            if (TryGetDiagonal(position, out var diagonal))
                yield return diagonal;

            if (TryGetAntidiagonal(position, out var antidiagonal))
                yield return antidiagonal;
        }

        public IEnumerable<IEnumerable<ICell>> GetRows()
        {
            for (var i = 0; i < Height; i++)
                yield return GetRow(i);
        }

        public IEnumerable<ICell> GetRow(int index)
        {
            for (var columnIndex = 0; columnIndex < Width; columnIndex++)
                yield return new Cell(this, rowIndex: index, columnIndex);
        }

        public IEnumerable<IEnumerable<ICell>> GetColumns()
        {
            for (var i = 0; i < Width; i++)
                yield return GetColumn(i);
        }

        public IEnumerable<ICell> GetColumn(int index)
        {
            for (var rowIndex = 0; rowIndex < Height; rowIndex++)
                yield return new Cell(this, rowIndex, columnIndex: index);
        }

        /// <summary> Get diagonal (from top left end to bottom right end) and antidiagonal (from top right end to bottom left end). </summary>
        public IEnumerable<IEnumerable<ICell>> GetDiagonals()
        {
            yield return GetDiagonal();
            yield return GetAntidiagonal();
        }

        /// <summary> Get diagonal from top left end to bottom right end if given position belongs to it. </summary>
        public bool TryGetDiagonal(Position position, out IEnumerable<ICell> diagonal)
        {
            diagonal = GetDiagonal().ToList();
            var diagonalPositions = diagonal.Select(c => c.Position);

            if (!diagonalPositions.Contains(position))
            {
                diagonal = Enumerable.Empty<ICell>();

                return false;
            }

            return true;
        }

        /// <summary> Get diagonal from top left end to bottom right end. </summary>
        public IEnumerable<ICell> GetDiagonal()
        {
            for (var position = new Position(row: 0, column: 0);
                position.Row < Height && position.Column < Width;
                position = new Position(position.Row + 1, position.Column + 1))
            {
                yield return new Cell(this, position);
            }
        }

        /// <summary> Get diagonal from top right end to bottom left end if given position belongs to it. </summary>
        public bool TryGetAntidiagonal(Position position, out IEnumerable<ICell> antidiagonal)
        {
            antidiagonal = GetDiagonal().ToList();
            var antidiagonalPositions = antidiagonal.Select(c => c.Position);

            if (!antidiagonalPositions.Contains(position))
            {
                antidiagonal = Enumerable.Empty<ICell>();

                return false;
            }

            return true;
        }

        /// <summary> Get diagonal from top right end to bottom left end. </summary>
        public IEnumerable<ICell> GetAntidiagonal()
        {
            for (var position = new Position(row: 0, column: Width - 1);
                position.Row < Height && position.Column >= 0;
                position = new Position(position.Row + 1, position.Column - 1))
            {
                yield return new Cell(this, position);
            }
        }

        public IEnumerator<Symbol?> GetEnumerator()
            => marks.ToEnumerable()
                .GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => marks.GetEnumerator();

        public const int Height = 3;
        public const int Width = 3;

        private readonly Symbol?[,] marks;
    }
}
