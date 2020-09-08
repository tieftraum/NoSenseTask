using System;
using System.Collections.Generic;
using System.Linq;

namespace NoSenseTask.Extensions
{
    public static class IEnumerableGenericExtensionHelper
    {
        public static IEnumerable<T> ThisDoesntMakeAnySense<T>(this IEnumerable<T> array,
            Predicate<T> predicateDel,
            Func<IEnumerable<T>, IEnumerable<T>> funcDel)
        {
            if (array == null || array.Count() == 0)
            {
                throw new ArgumentNullException($"Specified array is null");
            }

            foreach (var item in array)
            {
                if (predicateDel(item))
                {
                    return array;
                }
            }
            return funcDel(array);
        }

        public static IEnumerable<TSource> ThisDoesntMakeSense<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, Func<IEnumerable<TSource>, IEnumerable<TSource>> Generate)
        {
            if (source == null || source.Count() == 0) throw new ArgumentNullException("source is null");
            if (predicate == null) throw new ArgumentNullException("predicate is null");
            if (Generate == null) throw new ArgumentNullException("Delegate is null");

            foreach (TSource element in source)
            {
                if (predicate(element))
                    return source;
            }

            return Generate(source);
        }
    }
}
