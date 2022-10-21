using Microsoft.EntityFrameworkCore;
using ProjectExcersice.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectExcercise.Application.Common.Interfaces
{
    public interface IMovieDbContext
    {
        DbSet<Movie> Movies { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
