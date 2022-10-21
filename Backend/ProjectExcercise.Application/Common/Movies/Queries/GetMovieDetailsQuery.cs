using MediatR;
using ProjectExcercise.Application.Common.Movies.Dtos;

namespace ProjectExcercise.Application.Common.Movies.Queries
{
    public class GetMovieDetailsQuery : IRequest<MovieDetailsDto>
    {
        public int Id { get; set; }
    }
}
