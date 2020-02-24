using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Example.Api.Extensions
{
    public static class HeaderDictionaryExtensions
    {
        public static void AddPaginationMetadata(this IHeaderDictionary headers, int totalCount, int pageSize, int currentPage, int totalPages)
        {
            var metadata = new
            {
                totalCount,
                pageSize,
                currentPage,
                totalPages
            };

            headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));
        }
    }
}