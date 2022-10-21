using ProjectExcercise.Application.Common.Actors.Dtos;

namespace ProjectExcercise.Application.Common.Movies.Dtos
{
    public class MovieDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public double Ratings { get; set; }
        public string? Description { get; set; }
        public string? Certification { get; set; }
        public ICollection<ActorDto> Actors { get; set; } = new List<ActorDto>();
        public string? Picture { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? Language { get; set; }
    }
}
