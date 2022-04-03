using System.Collections.Generic;

namespace System.Linq
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> AsAsyncQueryable<T>(this IEnumerable<T> input)
        {
            return new AsyncEnumerable<T>(input);
        }
    }
}
