namespace XO.Core.Components
{
    public class ReadOnlyCell
    {
        public ReadOnlyCell(IReadOnlyGrid grid, int rowIndex, int columnIndex)
            : this(grid, new Position(rowIndex, columnIndex))
        { }

        public ReadOnlyCell(IReadOnlyGrid grid, Position position)
        {
            this.grid = grid;
            Position = position;
        }

        public Position Position { get; }

        public Symbol? Value
            => grid[Position];

        public bool Empty
            => Value is null;

        public bool IsCenter()
            => grid.GetCenter().Position == Position;

        public bool IsCorner()
            => grid.GetCorners()
                .Select(c => c.Position)
                .Contains(Position);


        private readonly IReadOnlyGrid grid;
    }
}
