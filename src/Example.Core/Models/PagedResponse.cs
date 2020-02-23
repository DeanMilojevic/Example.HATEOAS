using System;
using System.Collections.Generic;

namespace Example.Core.Models
{
    public class PagedResponse<T> : List<T>
    {
        public PagedResponse(IEnumerable<T> items, int totalCount, int currentPage, int pageSize)
        {
            TotalCount = totalCount;
            Page = currentPage;
            Size = pageSize;

            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            AddRange(items);
        }

        public int TotalCount { get; }
        public int Page { get; }
        public int TotalPages { get; }
        public int Size { get; }

        public bool HasPrevious => Page > 1;
        public bool HasNext => Page < TotalPages;
    }
}
