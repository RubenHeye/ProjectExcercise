using Microsoft.EntityFrameworkCore;
using ProjectExcercise.Application.Common.Interfaces;
using ProjectExcersice.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectExcercise.Infrastructure.Persistence
{
    public class MovieDbContext : DbContext, IMovieDbContext
    {
        public DbSet<Movie> Movies => Set<Movie>();

        public MovieDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
