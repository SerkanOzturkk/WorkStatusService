using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using Task = Entities.Concrete.Task;

namespace Entities.Abstract;

public interface ITaskDal : IEntityRepository<Task>
{
    List<TaskDetailDto> GetTaskDetails();
    List<GetTaskDto> GetTasksByEmployeeId(int employeeId);
}