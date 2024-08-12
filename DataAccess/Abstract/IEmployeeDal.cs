using Core.DataAccess;
using Entities.Concrete;

namespace Entities.Abstract;

public interface IEmployeeDal : IEntityRepository<Employee>
{
}