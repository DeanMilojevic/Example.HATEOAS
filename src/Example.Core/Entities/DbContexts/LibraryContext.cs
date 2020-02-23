using System;
using Microsoft.EntityFrameworkCore;

namespace Example.Core.Entities.DbContexts
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Author>()
                .HasData(
                new Author
                {
                    Id = Guid.Parse("d3ffc876-970b-4584-9cdd-a1413ca63267"),
                    FirstName = "Dean",
                    LastName = "Milojevic",

                });

            modelBuilder
                .Entity<Course>()
                .HasData(
                new Course
                {
                    Id = Guid.Parse("90818d8b-7a6b-4375-85cf-12b3b6b181b1"),
                    Title = "Some random title",
                    AuthorId = Guid.Parse("d3ffc876-970b-4584-9cdd-a1413ca63267")
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
