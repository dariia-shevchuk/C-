using System;
using System.Collections.Generic;

namespace DelegateFour
{
    public static class ListExtensions
    {
        public static List<T> MyFindAllMethod<T>(this List<T> list, Predicate<T> predicate)
        {
            var result = new List<T>();
            foreach(var item in list)
            {
                if (predicate.Invoke(item))
                    result.Add(item);
            }
            return result;
        }
    }
}
