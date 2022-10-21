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
    public class GetMoviesbyActorsHandler : IRequestHandler<GetMoviesByActorQuery, MovieDto[]>
    {
        private readonly IMovieService _movieService;

        public GetMoviesbyActorsHandler(IMovieService movieService)
        {
            this._movieService = movieService;
        }
        public async Task<MovieDto[]> Handle(GetMoviesByActorQuery request, CancellationToken cancellationToken)
        {
            return await _movieService.GetMoviesByActorAsync(request.Id);
        }
    }
}
