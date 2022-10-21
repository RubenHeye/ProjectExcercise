using AutoMapper;
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
        private readonly IMapper _mapper;

        public MovieService(IMovieDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<MovieDetailsDto> GetMovieDetailsAsync(int id)
        {
            var movie = await dbContext.Movies.Include(x => x.Actor).FirstOrDefaultAsync(x => x.Id == id);
            var movieDto = _mapper.Map<MovieDetailsDto>(movie);

            return movieDto;
        }

        public async Task<MovieDto[]> GetMoviesAsync()
        {
            var movies = await dbContext.Movies.ToArrayAsync();
            var moviesDto = new MovieDto[movies.Length];
            for(int i = 0; i < movies.Length; i++)
            {
                moviesDto[i] = _mapper.Map<MovieDto>(movies[i]);
            }

            return moviesDto;
        }
    }
}
