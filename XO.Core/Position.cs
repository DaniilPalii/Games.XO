namespace XO.Core
{
    public struct Position
    {
        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Row { get; }

        public int Column { get; }

        public override string ToString()
        {
            var columnSymbol = Column switch
            {
                0 => 'A',
                1 => 'B',
                2 => 'C',
                _ => throw new ArgumentOutOfRangeException(nameof(Column)),
            };

            var rowSymbol = Row switch
            {
                0 => '1',
                1 => '2',
                2 => '3',
                _ => throw new ArgumentOutOfRangeException(nameof(Row)),
            };

            return $"{columnSymbol}{rowSymbol}";
        }
    }
}
