using Invento.Api.DI.Repositories;
using Invento.Api.Models;

namespace Invento.Api.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        public Task<List<TaskModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public TaskModel GetAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Task model)
        {
            throw new NotImplementedException();
        }
    }
}
