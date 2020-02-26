using Microsoft.EntityFrameworkCore;

namespace Example.Core.Entities.DbContexts
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
