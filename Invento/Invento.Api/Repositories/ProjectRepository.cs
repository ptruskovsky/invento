using Invento.Api.Data;
using Invento.Api.DI.Repositories;
using Invento.Api.Models;

using Microsoft.EntityFrameworkCore;

namespace Invento.Api.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly InventoDbContext _context;
        public ProjectRepository(InventoDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProjectModel>> GetAllAsync()
        {
            return await _context.Projects.Select(x => new ProjectModel
            {
                Id = x.Id,
                Name = x.Name,
                Owner = x.Owner,
            })
            .ToListAsync();  
            
        }

        public Task<ProjectModel> GetAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(ProjectModel model)
        {
            throw new NotImplementedException();
        }
    }
}
