using Core.DataAccess;
using Entities.Concrete;

namespace Entities.Abstract;

public interface IEmployeeClaimDal : IEntityRepository<EmployeeClaim>
{
}