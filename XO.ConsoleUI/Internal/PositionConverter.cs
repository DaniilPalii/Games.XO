using System.Text.RegularExpressions;
using XO.Core;

namespace XO.ConsoleUI.Internal
{
    internal static class PositionConverter
    {
        public static string ToString(this Position position)
        {
            var columnSymbol = position.Column switch
            {
                0 => 'A',
                1 => 'B',
                2 => 'C',
                _ => throw new ArgumentOutOfRangeException(nameof(position)),
            };

            var rowSymbol = position.Row switch
            {
                0 => '1',
                1 => '2',
                2 => '3',
                _ => throw new ArgumentOutOfRangeException(nameof(position)),
            };

            return $"{columnSymbol}{rowSymbol}";
        }

        public static Position ToPosition(this string position)
        {
            var positionElements = positionRegex.Match(position).Groups;

            var columnSymbol = positionElements[1].Value;
            var rowSymbol = positionElements[2].Value;

            var columnIndex = columnSymbol switch
            {
                "A" => 0,
                "B" => 1,
                "C" => 2,
                _ => throw new ArgumentOutOfRangeException(nameof(position)),
            };

            var rowIndex = rowSymbol switch
            {
                "1" => 0,
                "2" => 1,
                "3" => 2,
                _ => throw new ArgumentOutOfRangeException(nameof(position)),
            };

            return new(rowIndex, columnIndex);
        }

        private static readonly Regex positionRegex = new("([ABC])([123])");
    }
}
