namespace Invento.Api.Data.Entities
{
    public class Project
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Owner { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public virtual ICollection<Task> Tasks { get; set; } = new HashSet<Task>();
    }
}
