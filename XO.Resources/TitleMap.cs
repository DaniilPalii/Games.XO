using XO.Core.Players;
using XO.SystemExtensions.Exceptions;

namespace XO.Resources
{
    public static class TitleMap
    {
        public static string GetFor(PlayerKind playerKind)
            => playerKind switch
            {
                PlayerKind.Human => Titles.Human,
                PlayerKind.RandomizingComputer => Titles.RandomizingComputer,
                _ => throw new UnhandledEnumValueException(playerKind),
            };
    }
}
