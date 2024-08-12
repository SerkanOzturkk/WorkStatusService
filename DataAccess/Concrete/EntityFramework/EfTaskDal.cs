using Core.DataAccess.EntityFramework;
using Entities.Abstract;
using Task = Entities.Concrete.Task;

namespace DataAccess.Concrete.EntityFramework;

public class EfTaskDal : EfEntityRepositoryBase<Task, WorkStatusContext>, ITaskDal
{
}