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
    public class GetMovieDetailsHandler : IRequestHandler<GetMovieDetailsQuery, MovieDetailsDto>
    {
        private readonly IMovieService _movieService;

        public GetMovieDetailsHandler(IMovieService movieService)
        {
            _movieService = movieService;
        }
    
        public async Task<MovieDetailsDto> Handle(GetMovieDetailsQuery request, CancellationToken cancellationToken)
        {
            var movie = await _movieService.GetMovieDetailsAsync(request.Id);

            return movie;

        }
    }
}
