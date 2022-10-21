using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectExcercise.Application.Common.Interfaces;
using ProjectExcercise.Application.Common.Movies.Dtos;
using ProjectExcercise.Application.Common.Movies.Queries;
using System.Net;

namespace ProjectExcercise.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(MovieDto[]))]
        public async Task<ActionResult> GetAllMovies()
        {
            var movies = await _mediator.Send(new GetMoviesQuery());
            return Ok(movies);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(MovieDetailsDto))]
        public async Task<ActionResult> GetMovieDetails(int id)
        {
            var movie = await _mediator.Send(new GetMovieDetailsQuery { Id = id });
            return Ok(movie);
        }
    }
}
