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
                    TeamName = t.TeamName
                };
            return result.ToList();
        }
    }
}