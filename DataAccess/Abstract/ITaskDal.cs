using Core.DataAccess;
using Entities.Concrete;
using Task = Entities.Concrete.Task;

namespace Entities.Abstract;

public interface ITaskDal : IEntityRepository<Task>
{
}