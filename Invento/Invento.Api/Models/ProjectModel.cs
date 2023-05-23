using System.Linq.Expressions;
using Invento.Api.Data.Entities;

namespace Invento.Api.Models
{
    public class ProjectModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Owner { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public IEnumerable<TaskModel> Tasks { get; set; } = Enumerable.Empty<TaskModel>();

        public static Expression<Func<Project, ProjectModel>> FromEntity =>
            entity => new ProjectModel {
                Id = entity.Id,
                Name = entity.Name,
                Owner = entity.Owner,
                IsActive = entity.IsActive,
                Tasks = entity.Tasks.Select(x => new TaskModel {
                    Id = x.Id,
                    Name = x.Name,
                    Owner = x.Owner,
                    IsActive = x.IsActive,
                })
            };

        public Project ToEntity(Project? entity = null) {
            entity ??= new Project();
            entity.Name = Name;

            return entity;
        }
    }
}
