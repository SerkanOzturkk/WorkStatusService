namespace Entities.Concrete;

public class Claim
{
    public int ClaimId { get; set; }
    public string ClaimName { get; set; }  // Example: "can_edit_tasks", "can_view_reports"

    public ICollection<EmployeeClaim> EmployeeClaims { get; set; }
}