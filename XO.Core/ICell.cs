namespace XO.Core
{
    public interface ICell
    {
        Position Position { get; }

        Symbol? Value { get; set; }

        bool Empty { get; }
    }
}
