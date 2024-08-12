using Core.Abstract;

namespace Entities.Concrete;

public class Task : IEntity
{
    public int TaskId { get; set; }
    public string TaskName { get; set; }
    public int ProjectId { get; set; }
    public int AssignedEmployeeId { get; set; }
    public string Status { get; set; }
    public DateTime? CompletionDate { get; set; }
    public bool ManagerApproval { get; set; }
    public DateTime CreatedAt { get; set; }

    public Project Project { get; set; }
    public Employee AssignedEmployee { get; set; }
    public ICollection<TimeLog> TimeLogs { get; set; }
}