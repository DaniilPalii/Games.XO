namespace XO.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool AreEqual<T>(this IEnumerable<T> elements)
        {
            var firstElement = elements.First();

            return elements.Skip(1)
                .All(e => Equals(firstElement, e));
        }
    }
}
