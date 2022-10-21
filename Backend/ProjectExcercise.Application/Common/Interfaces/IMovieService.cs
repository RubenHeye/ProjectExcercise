using ProjectExcercise.Application.Common.Movies.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectExcercise.Application.Common.Interfaces
{
    public interface IMovieService
    {
        Task<MovieDto[]> GetMoviesAsync();
        Task<MovieDto[]> GetMoviesByActorAsync(int actorId);
    }
}
