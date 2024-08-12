using Core.Abstract;

namespace Entities.Concrete;

public class EmployeeClaim : IEntity
{
    public int EmployeeClaimId { get; set; }
    public int EmployeeId { get; set; }
    public int ClaimId { get; set; }

    public Employee Employee { get; set; }
    public Claim Claim { get; set; }
}