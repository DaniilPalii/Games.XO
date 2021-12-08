namespace XO.SystemExtensions
{
    public static class EnumerableExtensions
    {
        public static bool AreEqual<T>(this IEnumerable<T> elements)
        {
            var firstElement = elements.First();

            return elements.Skip(1)
                .All(e => Equals(firstElement, e));
        }

        public static IEnumerable<T> RepeatEndless<T>(this IEnumerable<T> elements)
        {
            while (true)
                foreach (var element in elements)
                    yield return element;
        }
    }
}
