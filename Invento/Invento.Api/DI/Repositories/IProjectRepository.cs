﻿using Invento.Api.Models;

namespace Invento.Api.DI.Repositories
{
    public interface IProjectRepository
    {
        public Task SaveAsync(ProjectModel model);
        public Task<ProjectModel?> GetAsync(string Id, string? onwer = null);
        public Task<List<ProjectModel>> GetAllAsync(string? owner = null);
        public Task DeleteAsync(string id, string? owner = null);
    }
}
