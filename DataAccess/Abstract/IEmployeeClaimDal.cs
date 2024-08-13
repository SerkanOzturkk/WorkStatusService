using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace Entities.Abstract;

public interface IEmployeeClaimDal : IEntityRepository<EmployeeClaim>
{
    List<EmployeeClaimDetailDto> GetEmployeeClaimDetails();
}