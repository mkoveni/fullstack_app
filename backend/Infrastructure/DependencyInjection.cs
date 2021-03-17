using System;
using System.Net.Http;
using AutoMapper;
using Core.Contracts.Repositories;
using Infrastructure.Profiles;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string swapiBaseUrl, string chuckBaseUrl)
        {

            services.AddAutoMapper(typeof(AutoMapperProfiles));

            services.AddScoped<ISwapiRepository>(serviceCollection =>
            {
                return new SwapiRepository(
                    new HttpClient
                    {
                        BaseAddress = new Uri(swapiBaseUrl)
                    },
                     serviceCollection.GetService<IMapper>()
                );
            });

            services.AddScoped<IChuckRepository>(serviceCollection =>
            {

                return new ChuckRepository(
                    new HttpClient
                    {
                        BaseAddress = new Uri(chuckBaseUrl)
                    },
                    serviceCollection.GetService<IMapper>()
                );
            });

            
            return services;
        }
    }
}