namespace XO.SystemExtensions
{
    public static class RandomExtensions
    {
        public static T Next<T>(this Random random, IReadOnlyList<T> elements)
            => elements[random.Next(elements.Count)];
    }
}
