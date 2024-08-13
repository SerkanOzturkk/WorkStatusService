using Core.Entities;

namespace Entities.DTOs;

public class TimeLogDetailDto : IDto
{
    public int Id { get; set; }
    public string EmployeeName { get; set; }
    public string TaskName { get; set; }
    public DateTime Date { get; set; }
    public float HoursWorked { get; set; }
    public float OvertimeHours { get; set; }
}