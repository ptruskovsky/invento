using Invento.Api.DI.Context;
using Invento.Api.DI.Repositories;
using Invento.Api.Models;

using Microsoft.EntityFrameworkCore;

namespace Invento.Api.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IInventoDbContextFactory _contextFactory;
        public ProjectRepository(IInventoDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<ProjectModel>> GetAllAsync(int? skip = null, int? take = null, string? owner = null)
        {
            var pageSkip = skip ?? 0;
            var pageTake = take ?? int.MaxValue;
            
            using var ctx = _contextFactory.CreateRead();
            return await ctx.Projects
                    .Where(x => (x.Owner == owner || owner == null) && x.IsActive)
                    .Select(ProjectModel.FromEntity)
                    .OrderBy(x => x.Owner)
                    .Skip(pageSkip)
                    .Take(pageTake)
                    .ToListAsync();
        }

        public async Task<ProjectModel?> GetAsync(string Id, string? owner = null)
        {
            using var ctx = _contextFactory.CreateRead();
            return await ctx.Projects
                    .Where(x => x.Id == Id && (x.Owner == owner || owner == null) && x.IsActive)
                    .Select(ProjectModel.FromEntity).FirstOrDefaultAsync();
        }

        public async Task DeleteAsync(string id, string? owner = null) {
            using var ctx = _contextFactory.CreateWrite();
            var existing = await ctx.Projects.FirstAsync(x => x.Id == id && (x.Owner == owner || owner == null));

            existing.IsActive = false;

            await ctx.SaveChangesAsync();
        }

        public async Task AttachTaskToProject(string taskId, string projectId, string? owner = null) {
            using var ctx = _contextFactory.CreateWrite();
            var existingProject = await ctx.Projects.FirstAsync(x => x.Id == projectId && (x.Owner == owner || owner == null));
            var existingTask = await ctx.Tasks.FirstAsync(x => x.Id == taskId && (x.Owner == owner || owner == null));

            existingProject.Tasks.Add(existingTask);

            await ctx.SaveChangesAsync();
        }

        public async Task SaveAsync(ProjectModel model)
        {
            using var ctx = _contextFactory.CreateWrite();

            var entity = await ctx.Projects.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (entity == null) 
            {
                entity = new Data.Entities.Project 
                {
                    Id = Guid.NewGuid().ToString(),
                    IsActive = true,
                    Owner = model.Owner,
                };

                if (model.Tasks.Any()) 
                {
                    foreach (var task in model.Tasks) 
                    {
                        var newTask = new Data.Entities.Task {
                            Id = Guid.NewGuid().ToString(),
                            Name = task.Name,
                            Owner = model.Owner,
                            IsActive = true,
                        };

                        entity.Tasks.Add(newTask);
                    }
                }

                ctx.Projects.Add(entity);
            }

            model.ToEntity(entity);

            await ctx.SaveChangesAsync();
        }
    }
}
