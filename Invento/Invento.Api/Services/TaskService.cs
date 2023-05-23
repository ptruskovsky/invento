using Invento.Api.DI.Repositories;
using Invento.Api.DI.Services;
using Invento.Api.Models;

namespace Invento.Api.Services
{
    public class TaskService: ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository) {
            _taskRepository = taskRepository;
        }
        public Task DeleteAsync(string id, string? owner = null) =>
            _taskRepository.DeleteAsync(id, owner);

        public Task<List<TaskModel>> GetAllAsync(int? skip = null, int? take = null, string? owner = null) =>
            _taskRepository.GetAllAsync(skip, take, owner);


        public Task<TaskModel?> GetAsync(string Id, string? onwer = null) =>
            _taskRepository.GetAsync(Id, onwer);

        public Task SaveAsync(TaskModel model) =>
            _taskRepository.SaveAsync(model);
    }
}
