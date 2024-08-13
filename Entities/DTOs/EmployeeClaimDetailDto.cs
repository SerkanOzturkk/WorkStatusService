using Core.Entities;

namespace Entities.DTOs;

public class EmployeeClaimDetailDto : IDto
{
    public int Id { get; set; }
    public string EmployeeName { get; set; }
    public string ClaimName { get; set; }
}