using Invento.Api.Models;

namespace Invento.Api.DI.Repositories
{
    public interface ITaskRepository
    {
        public Task SaveAsync(TaskModel model);
        public Task<TaskModel?> GetAsync(string Id, string? owner = null);
        public Task<List<TaskModel>> GetAllAsync(int? skip = null, int? take = null, string? owner = null);
        public Task DeleteAsync(string id, string? owner = null);
    }
}
