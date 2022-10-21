using Microsoft.EntityFrameworkCore;
using ProjectExcercise.Application.Common.Interfaces;
using ProjectExcersice.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
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

            using (StreamReader r = new StreamReader("C:\\Users\\RHECM51\\source\\Projects\\Project Excercise\\ProjectExcercise\\ProjectExcercise.Infrastructure\\data.json"))
            {
                string json = r.ReadToEnd();
                List<Movie> movies = JsonSerializer.Deserialize<List<Movie>>(json)!;
                
                /*
                List<Actor> actors = new List<Actor>();
                foreach(var movie in movies)
                {
                    foreach(Actor actor in movie.Actors)
                    {
                        if (actors.Contains(actor))
                        {
                            actors.Add(actor);
                        }
                    }
                }

                modelBuilder.SharedTypeEntity<Dictionary<string, object>>("MovieActor", builder =>
                {
                    builder.Property<int>("MovieId");
                    builder.Property<int>("ActorId");
                    builder.HasKey("MovieId", "ActorId");

                });


                modelBuilder
                    .Entity<Movie>()
                    .HasMany(x => x.Actors)
                    .WithMany(x => x.Movies)
                    .UsingEntity<Dictionary<string, object>>("ActorMovie",
                       x => x.HasOne<Actor>().WithMany().HasForeignKey("ActorId"),
                       x => x.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                       x => x.ToTable("ActorMovie"))
                    .HasData();


                modelBuilder
                    .Entity<Actor>()
                    .HasData(actors);
                */
                modelBuilder
                    .Entity<Movie>()
                    .HasData(movies);
            }



            base.OnModelCreating(modelBuilder);
        }
    }
}
