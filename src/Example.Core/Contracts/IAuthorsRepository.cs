using System;
using Example.Core.Entities;
using Example.Core.Models;

namespace Example.Core.Contracts
{
    public interface IAuthorsRepository : IDisposable
    {
        PagedResponse<Author> GetAuthors(string searchQuery, int pageNumbere, int pageSize);
        void Insert(Author author);
        void Delete(Author author);
    }
}
