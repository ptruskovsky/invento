using Invento.Api.DI.Repositories;
using Invento.Api.DI.Services;
using Invento.Api.Models;

namespace Invento.Api.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public Task<List<ProjectModel>> GetAllAsync()
            => _projectRepository.GetAllAsync();
    }
}
