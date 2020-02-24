using System.Linq;
using Example.Core.Models;

namespace Example.Core.Extensions
{
    public static class QueryableExtensions
    {
        public static PagedResponse<T> ToPagedResponse<T>(this IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedResponse<T>(items, count, pageNumber, pageSize);
        }
    }
}
