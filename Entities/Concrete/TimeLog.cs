using Core.Abstract;

namespace Entities.Concrete;

public class TimeLog : IEntity
{
    public int TimeLogId { get; set; }
    public int EmployeeId { get; set; }
    public int TaskId { get; set; }
    public DateTime Date { get; set; }
    public float HoursWorked { get; set; }
    public float OvertimeHours { get; set; }
    public DateTime CreatedAt { get; set; }

    public Employee Employee { get; set; }
    public Task Task { get; set; }
}