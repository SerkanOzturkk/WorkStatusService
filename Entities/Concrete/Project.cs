using Core.Abstract;

namespace Entities.Concrete;

public class Project : IEntity
{
    public int ProjectId { get; set; }
    public string ProjectName { get; set; }
    public int TeamId { get; set; }
    public DateTime CreatedAt { get; set; }

    public Team Team { get; set; }
    public ICollection<Task> Tasks { get; set; }
}