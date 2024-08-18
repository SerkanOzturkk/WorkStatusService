using Core.Entities;

namespace Entities.DTOs;

public class EmployeeForLoginDto : IDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}