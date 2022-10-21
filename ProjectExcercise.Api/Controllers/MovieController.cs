using Microsoft.AspNetCore.Mvc;
using ProjectExcercise.Application.Common.Interfaces;
using ProjectExcercise.Application.Common.Movies.Dtos;
using System.Net;

namespace ProjectExcercise.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(MovieDto[]))]
        public async Task<ActionResult> GetAllMovies()
        {
            return Ok();
        }
    }
}
