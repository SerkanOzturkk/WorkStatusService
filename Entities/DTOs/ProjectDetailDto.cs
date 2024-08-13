using Core.Entities;

namespace Entities.DTOs;

public class ProjectDetailDto : IDto
{
    public int Id { get; set; }
    public string ProjectName { get; set; }
    public string TeamName { get; set; }
}