using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectExcercise.Application.Common.Interfaces;
using ProjectExcercise.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectExcercise.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<MovieDbContext>(options =>
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ProjectExcercise;Trusted_Connection=True;MultipleActiveResultSets=true"));

            services.AddScoped<IMovieDbContext>(collection => collection.GetRequiredService<MovieDbContext>());

            return services;
        }
    }
}
