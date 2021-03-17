using Core.Contracts.UseCases;
using Core.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<IGetCategories, GetCategories>();
            services.AddScoped<IGetRandomJoke, GetRandomJoke>();
            services.AddScoped<IGetStarWarsCharacters, GetStarWarsCharacters>();
            services.AddScoped<ISearchJokes, SearchJokes>();
            services.AddScoped<ISearchCharacters, SearchCharacters>();

            return services;
        }
    }
}