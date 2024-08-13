using Core.Abstract;
using Core.Entities;

namespace Entities.Concrete;

public class Project : BaseEntity
{
    public string ProjectName { get; set; }
    public int TeamId { get; set; }
    

    public Team Team { get; set; }
    public ICollection<Task> Tasks { get; set; }
}