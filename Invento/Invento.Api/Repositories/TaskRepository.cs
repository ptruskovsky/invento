using Invento.Api.DI.Context;
using Invento.Api.DI.Repositories;
using Invento.Api.Models;

using Microsoft.EntityFrameworkCore;

namespace Invento.Api.Repositories
{
    public class TaskRepository : ITaskRepository {

        private readonly IInventoDbContextFactory _contextFactory;

        public TaskRepository(IInventoDbContextFactory contextFactory) {
            _contextFactory = contextFactory;
        }

        public async Task DeleteAsync(string id, string? owner = null) {
            using var ctx = _contextFactory.CreateWrite();
            var existing = await ctx.Tasks.FirstAsync(x => x.Id == id && (x.Owner == owner || owner == null));

            existing.IsActive = false;

            await ctx.SaveChangesAsync();
        }

        public async Task<List<TaskModel>> GetAllAsync(int? skip = null, int? take = null, string? owner = null) {
            var pageSkip = skip ?? 0;
            var pageTake = take ?? int.MaxValue;

            using var ctx = _contextFactory.CreateRead();
            return await ctx.Tasks
                    .Where(x => (x.Owner == owner || owner == null) && x.IsActive)
                    .Select(TaskModel.FromEntity)
                    .OrderBy(x => x.Owner)
                    .Skip(pageSkip)
                    .Take(pageTake)
                    .ToListAsync();
        }

        public async Task<TaskModel?> GetAsync(string Id, string? owner = null) {
            using var ctx = _contextFactory.CreateRead();
            return await ctx.Tasks
                    .Where(x => x.Id == Id && (x.Owner == owner || owner == null) && x.IsActive)
                    .Select(TaskModel.FromEntity).FirstOrDefaultAsync();
        }

        public async Task SaveAsync(TaskModel model) {
            using var ctx = _contextFactory.CreateWrite();

            var entity = await ctx.Tasks.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (entity == null) {
                entity = new Data.Entities.Task {
                    Id = Guid.NewGuid().ToString(),
                    IsActive = true,
                    Owner = model.Owner,
                };
                ctx.Tasks.Add(entity);
            }

            model.ToEntity(entity);

            await ctx.SaveChangesAsync();
        }
    }
}
