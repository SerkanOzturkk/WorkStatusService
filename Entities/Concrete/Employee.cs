using Core.Abstract;

namespace Entities.Concrete;

public class Employee: IEntity
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public int TeamId { get; set; }
    public DateTime CreatedAt { get; set; }

    public Team Team { get; set; }
    public ICollection<Task> Tasks { get; set; }
    public ICollection<TimeLog> TimeLogs { get; set; }
    public ICollection<EmployeeClaim> EmployeeClaims { get; set; }
}