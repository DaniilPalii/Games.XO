using XO.SystemExtensions;

namespace XO.Core
{
    public static class CellExtensions
    {
        public static IEnumerable<Symbol?> Values(this IEnumerable<ICell> cells)
            => cells.Select(c => c.Value);

        public static bool HasThree(this IEnumerable<ICell> cells, Symbol symbol)
            => cells.Values().Has(symbol, times: 3);


        public static bool HasTwo(this IEnumerable<ICell> cells, Symbol symbol)
            => cells.Values().Has(symbol, times: 2);

        public static bool Has(this IEnumerable<ICell> cells, Symbol symbol)
            => cells.Values().Has(symbol);
    }
}
