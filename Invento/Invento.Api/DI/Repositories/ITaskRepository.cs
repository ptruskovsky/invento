using Invento.Api.Models;

namespace Invento.Api.DI.Repositories
{
    public interface ITaskRepository
    {
        public Task SaveAsync(Task model);
        public TaskModel GetAsync(int Id);
        public Task<List<TaskModel>> GetAllAsync();
    }
}
