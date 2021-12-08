using XO.Core;
using XO.SystemExtensions.Exceptions;

namespace XO.Resources
{
    public static class MessageMap
    {
        public static string GetFor(GameState gameState)
            => gameState switch
            {
                GameState.Pending => Messages.GamePending,
                GameState.Draw => Messages.Draw,
                GameState.XWin => Messages.PlayerXWin,
                GameState.OWin => Messages.PlayerOWin,
                _ => throw new UnhandledEnumValueException(gameState),
            };
    }
}
