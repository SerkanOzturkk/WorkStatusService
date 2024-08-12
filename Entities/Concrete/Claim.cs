using Core.Abstract;

namespace Entities.Concrete;

public class Claim : IEntity
{
    public int ClaimId { get; set; }
    public string ClaimName { get; set; }  // Example: "can_edit_tasks", "can_view_reports"

    public ICollection<EmployeeClaim> EmployeeClaims { get; set; }
}