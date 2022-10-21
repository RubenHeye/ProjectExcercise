using Microsoft.EntityFrameworkCore;
using ProjectExcercise.Application.Common.Interfaces;
using ProjectExcercise.Application.Common.Movies.Dtos;
using ProjectExcersice.Domain;
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
                .ToArrayAsync();
        }

        public async Task<MovieDto[]> GetMoviesByActorAsync(int actorId)
        {
            return await dbContext.Movies
                .Where(x => x.Actors.Select(x => x.Id).Contains(actorId))
                .Select(t => new MovieDto()
                {
                    Id = t.Id,
                    Title = t.Title,
                    ReleaseDate = t.ReleaseDate,
                    PictureUri = t.Picture,
                })
                .ToArrayAsync();
        }
    }
}
