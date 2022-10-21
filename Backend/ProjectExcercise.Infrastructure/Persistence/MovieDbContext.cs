﻿using Microsoft.EntityFrameworkCore;
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

            using (StreamReader r = new StreamReader("C:\\Users\\RHECM51\\source\\Projects\\Project Excercise\\ProjectExcercise\\Backend\\ProjectExcercise.Infrastructure\\data.json"))
            {
                string json = r.ReadToEnd();
                List<Movie> movies = JsonSerializer.Deserialize<List<Movie>>(json)!;
                var tmpActors = JsonSerializer.Deserialize<List<Actor>>(json)!;
                List<KeyValuePair<int, int>> movieActor = new List<KeyValuePair<int, int>>();



                List<Actor> actors = new List<Actor>();
                foreach (var movie in movies)
                {
                    foreach (Actor actor in movie.Actors)
                    {
                        movieActor.Add(new KeyValuePair<int, int>(movie.Id, actor.Id));
                        if (!actors.Select(x => x.Id).Contains(actor.Id))
                        {
                            actors.Add(actor);
                        }
                    }
                    movie.Actors = new List<Actor>();
                }
                modelBuilder
                    .Entity<Actor>()
                    .HasData(actors);
                modelBuilder
                    .Entity<Movie>()
                    .HasData(movies);
                modelBuilder
                    .Entity<Movie>()
                    .HasMany(x => x.Actors)
                    .WithMany(x => x.Movies)
                    .UsingEntity<Dictionary<string, object>>("ActorMovie",
                       x => x.HasOne<Actor>().WithMany().HasForeignKey("ActorId"),
                       x => x.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                       x =>
                       {
                           x.HasKey("MovieId", "ActorId");
                           foreach (var item in movieActor)
                               x.HasData(new { MovieId = item.Key, ActorId = item.Value });
                       });
            }



            base.OnModelCreating(modelBuilder);
        }
    }
}
