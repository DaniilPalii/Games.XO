namespace XO.Core.Internal
{
    internal class Cell : ICell
    {
        public Cell(Grid grid, int rowIndex, int columnIndex)
            : this(grid, new Position(rowIndex, columnIndex))
        { }

        public Cell(Grid grid, Position position)
        {
            this.grid = grid;
            Position = position;
        }

        public Position Position { get; }

        public Symbol? Value
        {
            get => grid[Position];
            set => grid[Position] = value;
        }

        public bool Empty
            => Value is null;

        private readonly Grid grid;
    }
}
