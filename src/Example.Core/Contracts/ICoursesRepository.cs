using System;
using Example.Core.Entities;

namespace Example.Core.Contracts
{
    public interface ICoursesRepository : IDisposable
    {
        void Insert(Course course);
        void Delete(Course course);
    }
}
