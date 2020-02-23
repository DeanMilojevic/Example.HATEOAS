using System;
using Example.Core.Entities;

namespace Example.Core.Contracts
{
    public interface IAuthorsRepository : IDisposable
    {
        void Insert(Author author);
        void Delete(Author author);
    }
}
