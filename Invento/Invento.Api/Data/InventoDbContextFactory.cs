using Invento.Api.DI.Context;
using Microsoft.EntityFrameworkCore;

namespace Invento.Api.Data {
    public class InventoDbContextFactory : IInventoDbContextFactory {

        private static DbContextOptions<InventoDbContext> _options;

        static InventoDbContextFactory() {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<InventoDbContext>();
            dbContextOptionsBuilder.UseInMemoryDatabase("invento");
            _options = dbContextOptionsBuilder.Options;
        }

        public IInventoDbContext CreateRead() {
            var context = new InventoDbContext(_options);
            context.ChangeTracker.LazyLoadingEnabled = false;
            return context;
        }

        public IInventoDbContext CreateWrite() {
            var context = new InventoDbContext(_options);
            return context;
        }
    }
}
