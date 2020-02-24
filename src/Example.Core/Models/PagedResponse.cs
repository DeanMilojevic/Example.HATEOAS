using System;
using System.Collections.Generic;

namespace Example.Core.Models
{
    public class PagedResponse<T> : List<T>
    {
        public PagedResponse(IEnumerable<T> items, int totalCount, int currentPage, int pageSize)
        {
            TotalCount = totalCount;
            CurrentPage = currentPage;
            PageSize = pageSize;

            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            AddRange(items);
        }

        public int TotalCount { get; }
        public int CurrentPage { get; }
        public int TotalPages { get; }
        public int PageSize { get; }

        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
    }
}
