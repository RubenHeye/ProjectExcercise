using Microsoft.EntityFrameworkCore;
using ProjectExcercise.Application.Common.Interfaces;
using ProjectExcersice.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectExcercise.Infrastructure.Persistence
{
    public class MovieDbContext : DbContext, IMovieDbContext
    {
        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Actor> Actors => Set<Actor>();

        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //SeedingData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }


        private void SeedingData(ModelBuilder modelBuilder)
        {
            using (StreamReader r = new StreamReader("C:\\Users\\DDPCN29\\Documents\\acADDemITCs\\ProjectExercice\\repos\\ProjectExcercise\\Backend\\ProjectExcercise.Infrastructure\\data.json"))
            {
                string json = r.ReadToEnd();
                List<Movie> movies = JsonSerializer.Deserialize<List<Movie>>(json)!;
                var tmpActors = JsonSerializer.Deserialize<List<Actor>>(json)!;
                List<KeyValuePair<int, int>> movieActor = new List<KeyValuePair<int, int>>();



                List<Actor> actors = new List<Actor>();
                foreach (var movie in movies)
                {
                    foreach (Actor actor in movie.Actor)
                    {
                        movieActor.Add(new KeyValuePair<int, int>(movie.Id, actor.Id));
                        if (!actors.Select(x => x.Id).Contains(actor.Id))
                        {
                            actors.Add(actor);
                        }
                    }
                    movie.Actor = new List<Actor>();
                }
                modelBuilder
                    .Entity<Actor>()
                    .HasData(actors);
                modelBuilder
                    .Entity<Movie>()
                    .HasData(movies);
                modelBuilder
                    .Entity<Movie>()
                    .HasMany(x => x.Actor)
                    .WithMany(x => x.Movie)
                    .UsingEntity<Dictionary<string, object>>("ActorMovie",
                       x => x.HasOne<Actor>().WithMany().HasForeignKey("ActorsId"),
                       x => x.HasOne<Movie>().WithMany().HasForeignKey("MoviesId"),
                       x =>
                       {
                           x.HasKey("MoviesId", "ActorsId");
                           foreach (var item in movieActor)
                               x.HasData(new { MovieId = item.Key, ActorId = item.Value });
                       });
            }
        }
    }
}
