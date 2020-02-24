using System;
using System.Linq;
using Example.Core.Contracts;
using Example.Core.Entities;
using Example.Core.Entities.DbContexts;
using Example.Core.Extensions;
using Example.Core.Models;

namespace Example.Core.Repositories
{
    internal sealed class AuthorsRepository : IAuthorsRepository
    {
        private readonly LibraryContext _context;

        public AuthorsRepository(LibraryContext context)
        {
            _context = context;
        }

        public PagedResponse<Author> GetAuthors(string searchQuery, int pageNumber, int pageSize)
        {
            var collection = _context.Authors as IQueryable<Author>;

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                var query = searchQuery.Trim();

                collection = collection
                    .Where(author =>
                        author.FirstName.Contains(query) ||
                        author.LastName.Contains(query));
            }

            return collection.ToPagedResponse(pageNumber, pageSize);
        }

        public void Insert(Author author)
        {
            if (author is null)
            {
                throw new ArgumentNullException(nameof(author));
            }

            _context.Authors.Add(author);
        }

        public void Delete(Author author)
        {
            if (author is null)
            {
                throw new ArgumentNullException(nameof(author));
            }

            _context.Authors.Remove(author);
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }

        #region IDisposable Support

        private bool disposedValue = false;

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }
}
