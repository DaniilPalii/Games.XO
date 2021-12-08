using System.Collections;
using XO.SystemExtensions;

namespace XO.Core.Components
{
    public class ReadOnlyLine : IEnumerable<ReadOnlyCell>
    {
        public ReadOnlyLine(IEnumerable<ReadOnlyCell> cells)
            : this(cells.ToList())
        { }

        public ReadOnlyLine(IReadOnlyList<ReadOnlyCell> cells)
            => this.cells = cells;

        public virtual ReadOnlyCell this[int index]
            => cells[index];

        public IReadOnlyList<Position> Positions
            => positions
                ??= cells.Select(c => c.Position)
                    .ToList();

        public IReadOnlyList<Symbol?> Values
            => values
                ??= cells.Select(c => c.Value)
                    .ToList();

        public bool HasSingle(Symbol symbol)
            => Count(symbol) == 1;

        public bool HasTwo(Symbol symbol)
            => Count(symbol) == 2;

        public bool HasThree(Symbol symbol)
            => Count(symbol) == 3;

        public bool HasSingleEmpty()
            => CountEmpty() == 1;

        public bool HasTwoEmpty()
            => CountEmpty() == 2;

        public bool HasThreeEmpty()
            => CountEmpty() == 3;

        public int Count(Symbol symbol)
            => Values.Count(v => v == symbol);

        public int CountEmpty()
            => this.Count(c => c.Empty);

        public bool Contains(Symbol symbol, int times)
            => Values.Contains(symbol, times);

        public bool Contains(Symbol symbol)
            => Values.Contains(symbol);

        public IEnumerator<ReadOnlyCell> GetEnumerator()
            => cells.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private IReadOnlyList<Position>? positions;
        private IReadOnlyList<Symbol?>? values;
        private readonly IReadOnlyList<ReadOnlyCell> cells;
    }
}
