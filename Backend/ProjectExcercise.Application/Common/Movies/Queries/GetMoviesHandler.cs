using MediatR;
using ProjectExcercise.Application.Common.Interfaces;
using ProjectExcercise.Application.Common.Movies.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectExcercise.Application.Common.Movies.Queries
{
    public class GetMoviesHandler : IRequestHandler<GetMoviesQuery, MovieDto[]>
    {
        private readonly IMovieService _movieService;

        public GetMoviesHandler(IMovieService movieService)
        {
            this._movieService = movieService;
        }
        public async Task<MovieDto[]> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            return await _movieService.GetMoviesAsync();
        }
    }
}
