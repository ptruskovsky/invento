namespace Invento.Api.Data.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Owner { get; set; } = string.Empty;
        public virtual ICollection<Task> Tasks { get; set; } = new HashSet<Task>();
    }
}
