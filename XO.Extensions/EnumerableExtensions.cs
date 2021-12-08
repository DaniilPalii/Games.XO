using System.Diagnostics.CodeAnalysis;

namespace XO.SystemExtensions
{
    public static class EnumerableExtensions
    {
        public static bool Contains<T>(this IEnumerable<T> elements, T value, int times)
        {
            if (times <= 0)
                throw new ArgumentException(message: "Should be greater than 0", paramName: nameof(times));

            var count = 0;

            foreach (var element in elements)
                if (Equals(element, value))
                {
                    count++;

                    if (count == times)
                        return true;
                }

            return false;
        }

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

        public static bool TryGet<T>(this IEnumerable<T> elements, Func<T, bool> predicate, [MaybeNullWhen(false)] out T element)
        {
            element = elements.FirstOrDefault(predicate);

            return element is not null;
        }

        public static bool TryGet<T>(this IEnumerable<T> elements, [MaybeNullWhen(false)] out T element)
        {
            element = elements.FirstOrDefault();

            return element is not null;
        }
    }
}
