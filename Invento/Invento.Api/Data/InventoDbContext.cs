using Invento.Api.Data.Entities;
using Invento.Api.DI.Context;
using Microsoft.EntityFrameworkCore;

namespace Invento.Api.Data
{
    public class InventoDbContext : DbContext, IInventoDbContext {
        public InventoDbContext(DbContextOptions<InventoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Entities.Task> Tasks {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // config to do if needed
        }
    }
}
