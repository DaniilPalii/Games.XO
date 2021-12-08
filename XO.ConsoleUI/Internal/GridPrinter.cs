using System.Globalization;
using XO.Core;

namespace XO.ConsoleUI.Internal
{
    internal class GridPrinter
    {
        public GridPrinter(IReadOnlyGrid grid)
            => this.grid = grid;

        public string GetGrid()
        {
            var marks = this.grid.Select(ToString)
                .ToArray();

            return string.Format(
                CultureInfo.InvariantCulture,
                Resources.Grid,
                marks);
        }

        public IEnumerable<string> GetFreePositions()
            => this.grid.FreePositions
                .Select(p => PositionConverter.ToString(p))
                .OrderBy(p => p);

        private static string? ToString(Symbol? m)
            => m is null
                ? " "
                : m.ToString();

        private readonly IReadOnlyGrid grid;
    }
}
