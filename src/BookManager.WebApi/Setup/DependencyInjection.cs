using BookManager.Core.Communication.MediatR;
using BookManager.Data;
using BookManager.Data.Repository;
using BookManager.Domain.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BookManager.WebApi.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Domain Communication
            services.AddScoped<IMediatrHandler, MediatrHandler>();

            // Catalog
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<CatalogContext>();
        }
    }
}
