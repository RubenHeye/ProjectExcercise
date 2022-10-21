using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectExcersice.Domain
{
    public class Movie
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("runtime")]
        public int Duration { get; set; }
        [JsonPropertyName("vote_average")]
        public double Ratings { get; set; }
        [JsonPropertyName("overview")]
        public string? Description { get; set; }
        [JsonPropertyName("certification")]
        public string? Certification { get; set; }
        //[JsonPropertyName("cast")]
        //public ICollection<Actor> Actors { get; set; } = new List<Actor>();
        [JsonPropertyName("poster_path")]
        public string? Picture { get; set; }
        [JsonPropertyName("release_date")]
        public DateTime ReleaseDate { get; set; }
        [JsonPropertyName("original_language")]
        public string? Language { get; set; }
    }
}
