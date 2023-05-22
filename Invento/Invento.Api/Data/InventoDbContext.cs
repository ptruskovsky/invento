using Invento.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Invento.Api.Data
{
    public class InventoDbContext : DbContext
    {
        public InventoDbContext(DbContextOptions<InventoDbContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Entities.Task> Tasks {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasMany(x => x.Tasks);
        }
    }
}
