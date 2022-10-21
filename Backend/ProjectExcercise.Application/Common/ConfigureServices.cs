using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProjectExcercise.Application.Common.Interfaces;
using ProjectExcercise.Application.Common.Movies;
using ProjectExcercise.Application.Common.Movies.Dtos;
using ProjectExcercise.Application.Common.Movies.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjectExcercise.Application.Common
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
