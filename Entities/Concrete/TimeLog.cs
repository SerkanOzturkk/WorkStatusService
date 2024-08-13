using Core.Abstract;
using Core.Entities;

namespace Entities.Concrete;

public class TimeLog : BaseEntity
{

    public int EmployeeId { get; set; }
    public int TaskId { get; set; }
    public DateTime Date { get; set; }
    public float HoursWorked { get; set; }
    public float OvertimeHours { get; set; }


    public Employee Employee { get; set; }
    public Task Task { get; set; }
}