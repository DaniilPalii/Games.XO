using XO.SystemExtensions.Exceptions;

namespace XO.Core
{
    public static class SymbolExtensions
    {
        public static Symbol Next(this Symbol symbol)
            => symbol switch
            {
                Symbol.O => Symbol.X,
                Symbol.X => Symbol.O,
                _ => throw new UnhandledEnumValueException(symbol),
            };
    }
}
