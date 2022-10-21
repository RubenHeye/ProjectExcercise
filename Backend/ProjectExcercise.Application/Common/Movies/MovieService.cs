using Microsoft.EntityFrameworkCore;
using ProjectExcercise.Application.Common.Interfaces;
using ProjectExcercise.Application.Common.Movies.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectExcercise.Application.Common.Movies
{
    public class MovieService : IMovieService
    {
        private readonly IMovieDbContext dbContext;

        public MovieService(IMovieDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<MovieDto[]> GetMoviesAsync()
        {
            return await dbContext.Movies
                .Select(t => new MovieDto()
                {
                    Id = t.Id,
                    Title = t.Title,
                    ReleaseDate = t.ReleaseDate,
                    PictureUri = t.Picture,
                })
                .Take(100)
                .ToArrayAsync();
        }
    }
}
