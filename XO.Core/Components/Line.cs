namespace XO.Core.Components
{
    public class Line : ReadOnlyLine, IEnumerable<Cell>
    {
        public Line(IEnumerable<Cell> cells)
            : this(cells.ToList())
        { }

        public Line(IReadOnlyList<Cell> cells)
            : base(cells)
            => this.cells = cells;

        public override Cell this[int index]
            => cells[index];

        IEnumerator<Cell> IEnumerable<Cell>.GetEnumerator()
            => cells.GetEnumerator();

        private readonly IReadOnlyList<Cell> cells;
    }
}
