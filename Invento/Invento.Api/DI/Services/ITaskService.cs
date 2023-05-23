using Invento.Api.Models;

namespace Invento.Api.DI.Services
{
    public interface ITaskService
    {
        public Task DeleteAsync(string id, string? owner = null);
        public Task<List<TaskModel>> GetAllAsync(int? skip = null, int? take = null, string? owner = null);
        public Task<TaskModel?> GetAsync(string Id, string? onwer = null);
        public Task SaveAsync(TaskModel model);
    }
}
