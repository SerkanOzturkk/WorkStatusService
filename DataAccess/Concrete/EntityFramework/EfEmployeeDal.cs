using Core.DataAccess.EntityFramework;
using Entities.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework;

public class EfEmployeeDal : EfEntityRepositoryBase<Employee, WorkStatusContext>, IEmployeeDal
{
    public List<EmployeeDetailDto> GetEmployeeDetails()
    {
        using (WorkStatusContext context = new WorkStatusContext())
        {
            var result = from e in context.Employees
                join t in context.Teams
                    on e.TeamId equals t.Id
                select new EmployeeDetailDto
                {
                    Id = e.Id,
                    EmployeeName = e.EmployeeName,
                    TeamName = t.TeamName,
                    Email = e.Email,
                    Status = e.Status
                };
            return result.ToList();
        }
    }

    public List<OperationClaim> GetClaims(Employee employee)
    {
        using (var context = new WorkStatusContext())
        {
            var result = from operationClaim in context.OperationClaims
                join employeeClaim in context.EmployeeClaims
                    on operationClaim.Id equals employeeClaim.Id
                where employeeClaim.EmployeeId == employee.Id
                select new OperationClaim { Id = operationClaim.Id, ClaimName = operationClaim.ClaimName };
            return result.ToList();

        }
    }
}