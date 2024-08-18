using Core.Abstract;
using Core.Entities;

namespace Entities.Concrete;

public class OperationClaim : BaseEntity
{
    public string ClaimName { get; set; }  // Example: "can_edit_tasks", "can_view_reports"
    
    public ICollection<EmployeeClaim> EmployeeClaims { get; set; }
}