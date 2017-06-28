using System;
using System.Collections.Generic;
using System.Linq;

namespace Essential.Extensions
{    
    public static class LinqExtensions
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> list, int parts)
        {
            int i = 0;
            var splits = from item in list
                        group item by i++ % parts into part
                        select part.AsEnumerable();
            return splits;
        }

        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
            {
                action(item);
            }
        }

        public static IEnumerable<IEnumerable<T>> Batch<T>( 
            this IEnumerable<T> source, int batchSize) 
        { 
            using (var enumerator = source.GetEnumerator()) 
                while (enumerator.MoveNext()) 
                    yield return YieldBatchElements(enumerator, batchSize - 1); 
        } 

        private static IEnumerable<T> YieldBatchElements<T>( 
            IEnumerator<T> source, int batchSize) 
        { 
            yield return source.Current; 
            for (int i = 0; i < batchSize && source.MoveNext(); i++) 
                yield return source.Current; 
        } 
    }
}
