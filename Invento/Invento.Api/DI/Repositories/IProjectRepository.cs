using Invento.Api.Models;

namespace Invento.Api.DI.Repositories
{
    public interface IProjectRepository
    {
        public Task SaveAsync(ProjectModel model);
        public Task<ProjectModel> GetAsync(int Id);
        public Task<List<ProjectModel>> GetAllAsync();
    }
}
