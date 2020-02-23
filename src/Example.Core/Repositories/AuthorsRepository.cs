using System;
using Example.Core.Entities;
using Example.Core.Entities.DbContexts;

namespace Example.Core.Repositories
{
    public class AuthorsRepository : IDisposable
    {
        private readonly LibraryContext _context;

        public AuthorsRepository(LibraryContext context)
        {
            _context = context;
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

        protected virtual void Dispose(bool disposing)
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
