namespace XO.Core.Components
{
    public class Cell : ReadOnlyCell
    {
        public Cell(Grid grid, int rowIndex, int columnIndex)
            : this(grid, new Position(rowIndex, columnIndex))
        { }

        public Cell(Grid grid, Position position)
            : base(grid, position)
            => this.grid = grid;

        public new Symbol? Value
        {
            get => base.Value;
            set => grid[Position] = value;
        }

        private readonly Grid grid;
    }
}
