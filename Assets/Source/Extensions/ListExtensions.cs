using System.Collections.Generic;

namespace Extensions
{
    public static class ListExtensions
    {
        public static void AddSorted<T>(this List<T> list, T value)
        {
            int x = list.BinarySearch(value);
            list.Insert((x >= 0) ? x : ~x, value);
        }
    }
}