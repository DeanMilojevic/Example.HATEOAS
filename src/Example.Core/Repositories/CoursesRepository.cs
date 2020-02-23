using System;
using Example.Core.Contracts;
using Example.Core.Entities;
using Example.Core.Entities.DbContexts;

namespace Example.Core.Repositories
{
    internal sealed class CoursesRepository : ICoursesRepository
    {
        private readonly LibraryContext _context;

        public CoursesRepository(LibraryContext context)
        {
            _context = context;
        }

        public void Insert(Course course)
        {
            if (course is null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            _context.Courses.Add(course);
        }

        public void Delete(Course course)
        {
            if (course is null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            _context.Courses.Remove(course);
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
