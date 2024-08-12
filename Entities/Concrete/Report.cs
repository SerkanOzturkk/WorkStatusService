using Core.Abstract;

namespace Entities.Concrete;

public class Report : IEntity
{
    public int ReportId { get; set; }
    public string ReportType { get; set; }
    public DateTime ReportDate { get; set; }
    public int TeamId { get; set; }
    public int TotalTasksCompleted { get; set; }
    public int TotalTasksPending { get; set; }
    public DateTime CreatedAt { get; set; }

    public Team Team { get; set; }
}