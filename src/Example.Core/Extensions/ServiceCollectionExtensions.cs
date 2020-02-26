using Example.Core.Contracts;
using Example.Core.DbContexts;
using Example.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddDbContext<LibraryContext>(builder => builder.UseInMemoryDatabase("library"));

            services.AddTransient<IAuthorsRepository, AuthorsRepository>();
            services.AddTransient<ICoursesRepository, CoursesRepository>();

            return services;
        }
    }
}
