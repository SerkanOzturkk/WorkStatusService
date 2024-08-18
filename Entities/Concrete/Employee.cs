using Core.Abstract;
using Core.Entities;

namespace Entities.Concrete;

public class Employee: BaseEntity
{
    public string EmployeeName { get; set; }
    //public string FirstName { get; set; }
    //public string LastName { get; set; }
    public string Email { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public bool Status { get; set; }
    public int TeamId { get; set; }
    

    public Team Team { get; set; }
    public ICollection<Task> Tasks { get; set; }
    public ICollection<TimeLog> TimeLogs { get; set; }
    public ICollection<EmployeeClaim> EmployeeClaims { get; set; }
}