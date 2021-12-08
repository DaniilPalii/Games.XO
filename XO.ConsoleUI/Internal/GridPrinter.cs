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
            var marks = grid.Select(ToStringOrSpace)
                .ToArray();

            return string.Format(
                CultureInfo.InvariantCulture,
                Resources.Grid,
                marks);
        }

        private static string? ToStringOrSpace(Symbol? m)
            => m is not null
                ? m.ToString()
                : " ";

        private readonly IReadOnlyGrid grid;
    }
}
