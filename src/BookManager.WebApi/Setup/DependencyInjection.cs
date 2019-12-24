using Microsoft.Extensions.DependencyInjection;

namespace BookManager.WebApi.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatrHandler, MediatrHandler>();
        }
    }
}