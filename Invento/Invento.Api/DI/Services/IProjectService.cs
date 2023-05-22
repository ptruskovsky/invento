using Invento.Api.Models;

namespace Invento.Api.DI.Services
{
    public interface IProjectService
    {
        public Task<List<ProjectModel>> GetAllAsync();
    }
}
