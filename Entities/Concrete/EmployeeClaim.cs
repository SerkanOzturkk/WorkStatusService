using Core.Abstract;
using Core.Entities;

namespace Entities.Concrete;

public class EmployeeClaim : BaseEntity
{
    public int EmployeeId { get; set; }
    public int ClaimId { get; set; }
    

    public Employee Employee { get; set; }
    public OperationClaim Claim { get; set; }
}