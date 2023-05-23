using Invento.Api.Models;

namespace Invento.Api.DI.Services
{
    public interface IProjectService
    {
        public Task SaveAsync(ProjectModel model);
        public Task<ProjectModel?> GetAsync(string Id, string? onwer = null);
        public Task<List<ProjectModel>> GetAllAsync(int? skip = null, int? take = null, string? owner = null);
        public Task DeleteAsync(string id, string? owner = null);
        public Task AttachTaskToProject(string taskId, string projectId, string? owner = null);
    }
}
