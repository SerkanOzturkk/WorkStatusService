using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace Entities.Abstract;

public interface IEmployeeDal : IEntityRepository<Employee>
{
    List<EmployeeDetailDto> GetEmployeeDetails();
    List<OperationClaim> GetClaims(Employee employee);
}