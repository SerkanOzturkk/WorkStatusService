
using Core.Entities;

namespace Entities.DTOs;

public class ReportDetailDto : IDto
{
    public int Id { get; set; }
    public string ReportType { get; set; }
    public DateTime ReportDate { get; set; }
    public string TeamName { get; set; }
    public int TotalTasksCompleted { get; set; }
    public int TotalTasksPending { get; set; }
}