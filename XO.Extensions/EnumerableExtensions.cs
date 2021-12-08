namespace XO.SystemExtensions
{
    public static class EnumerableExtensions
    {
        public static bool Has<T>(this IEnumerable<T> elements, T match, int times)
        {
            var count = 0;

            foreach (var element in elements)
                if (Equals(element, match))
                {
                    count++;

                    if (count == times)
                        return true;
                }

            return false;
        }

        public static bool Has<T>(this IEnumerable<T> elements, T match)
               => elements.Any(e => Equals(e, match));

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
