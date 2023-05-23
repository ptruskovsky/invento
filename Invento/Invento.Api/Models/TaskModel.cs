using System.Linq.Expressions;
using System.Text.Json.Serialization;

using Invento.Api.Data.Entities;

namespace Invento.Api.Models
{
    public class TaskModel {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Owner { get; set; } = string.Empty;
        [JsonIgnore]
        public bool IsActive { get; set; }

        public static Expression<Func<Data.Entities.Task, TaskModel>> FromEntity =>
            entity => new TaskModel {
                Id = entity.Id,
                Name = entity.Name,
                Owner = entity.Owner,
                IsActive = entity.IsActive,
            };

        public Data.Entities.Task ToEntity(Data.Entities.Task? entity = null) {
            entity ??= new Data.Entities.Task();
            entity.Name = Name;

            return entity;
        }
    }
}
