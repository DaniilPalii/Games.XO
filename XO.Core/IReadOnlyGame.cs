namespace XO.Core
{
    public interface IReadOnlyGame
    {
        Symbol CurrentSymbol { get; }

        IReadOnlyGrid Grid { get; }

        GameState State { get; }
    }
}
