using Core.Entities;

namespace Entities.DTOs;

public class TaskDetailDto : IDto
{
    public int Id { get; set; }
    public string TaskName { get; set; }
    public string ProjectName { get; set; }
    public string AssignedEmployeeName { get; set; }
    public string Status { get; set; }
    public DateTime? CompletionDate { get; set; }
    public bool ManagerApproval { get; set; }
}