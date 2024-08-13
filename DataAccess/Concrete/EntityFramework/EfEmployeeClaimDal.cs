using Core.DataAccess.EntityFramework;
using Entities.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework;

public class EfEmployeeClaimDal : EfEntityRepositoryBase<EmployeeClaim, WorkStatusContext>, IEmployeeClaimDal
{
    public List<EmployeeClaimDetailDto> GetEmployeeClaimDetails()
    {
        using (WorkStatusContext context = new WorkStatusContext())
        {
            var result = from ec in context.EmployeeClaims
                join e in context.Employees
                    on ec.EmployeeId equals e.Id
                    join c in context.Claims
                    on ec.ClaimId equals c.Id
                select new EmployeeClaimDetailDto
                {
                    Id = ec.Id,
                    EmployeeName = e.EmployeeName,
                    ClaimName = c.ClaimName
                };
            return result.ToList();
        }
    }
}