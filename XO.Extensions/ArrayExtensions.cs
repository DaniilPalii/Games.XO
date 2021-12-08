namespace XO.SystemExtensions
{
    public static class ArrayExtensions
    {
        public static IEnumerable<T> ToEnumerable<T>(this T[,] array)
        {
            foreach (var item in array)
                yield return item;
        }
    }
}
