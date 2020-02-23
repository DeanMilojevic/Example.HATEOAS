using System.Linq;
using Example.Api.Models;

namespace Example.Api.Extensions
{
    public static class QueryableExtensions
    {
        public static PagedResponse<T> ToPagedResponse<T>(this IQueryable<T> source, int pageNumber, int pageSize)
        {
            var totalCount = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PagedResponse<T>(items, totalCount, pageNumber, pageSize);
        }
    }
}
