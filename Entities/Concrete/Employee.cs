using Core.Abstract;
using Core.Entities;

namespace Entities.Concrete;

public class Employee: BaseEntity
{
    public string EmployeeName { get; set; }
    public int TeamId { get; set; }
    

    public Team Team { get; set; }
    public ICollection<Task> Tasks { get; set; }
    public ICollection<TimeLog> TimeLogs { get; set; }
    public ICollection<EmployeeClaim> EmployeeClaims { get; set; }
}