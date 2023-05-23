using Invento.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Invento.Api.DI.Context {
    public interface IInventoDbContext : IDisposable {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Data.Entities.Task> Tasks { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
