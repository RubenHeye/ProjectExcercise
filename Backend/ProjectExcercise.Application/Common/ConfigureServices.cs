using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProjectExcercise.Application.Common.Interfaces;
using ProjectExcercise.Application.Common.Movies;
using ProjectExcercise.Application.Common.Profiles;
using System.Reflection;

namespace ProjectExcercise.Application.Common
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(MovieProfile));

            return services;
        }
    }
}
