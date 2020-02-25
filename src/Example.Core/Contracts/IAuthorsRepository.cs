using System;
using System.Collections.Generic;
using Example.Core.Entities;
using Example.Core.Models;

namespace Example.Core.Contracts
{
    public interface IAuthorsRepository : IDisposable
    {
        IEnumerable<Author> GetAuthors();
        PagedResponse<Author> GetAuthors(string searchQuery, int pageNumbere, int pageSize);
        Author GetAuthor(Guid authorId);
        void Insert(Author author);
        void Delete(Author author);
        bool Save();
    }
}
