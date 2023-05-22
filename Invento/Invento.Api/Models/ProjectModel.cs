namespace Invento.Api.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Owner { get; set; } = string.Empty;
        public IEnumerable<Task> Tasks { get; set; } = Enumerable.Empty<Task>();
    }
}
