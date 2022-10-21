using MediatR;
using ProjectExcercise.Application.Common.Movies.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectExcercise.Application.Common.Movies.Queries
{
    public class GetMoviesByActorQuery : IRequest<MovieDto[]>
    {
        public int Id { get; set; }
    }
}
