using Invento.Api.DI.Repositories;
using Invento.Api.DI.Services;
using Invento.Api.Models;

namespace Invento.Api.Services
{
    public class ProjectService : IProjectService {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public Task DeleteAsync(string id, string? owner = null) {
            return _projectRepository.DeleteAsync(id, owner);
        }
            
        public Task<List<ProjectModel>> GetAllAsync(string? owner = null) {
            return _projectRepository.GetAllAsync(owner);
        }
            
        public Task<ProjectModel?> GetAsync(string Id, string? onwer = null) {
            return _projectRepository.GetAsync(Id, onwer);
        }

        public Task SaveAsync(ProjectModel model) {
            return _projectRepository.SaveAsync(model);
        }
    }
}
