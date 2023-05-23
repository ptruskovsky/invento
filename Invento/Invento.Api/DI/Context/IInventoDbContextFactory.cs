namespace Invento.Api.DI.Context {
    public interface IInventoDbContextFactory {
        IInventoDbContext CreateRead();
        IInventoDbContext CreateWrite();
    }
}
