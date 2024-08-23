using Core.Utilities.Results;
using Entities.DTOs;
using Task = Entities.Concrete.Task;

namespace Business.Abstract;

public interface ITaskService
{
    IDataResult<List<Task>> GetAll();
    IDataResult<List<Task>> GetAllByAssignedEmployeeId(int assignedEmployeeId);
    IDataResult<List<TaskDetailDto>> GetTaskDetails();
    IDataResult<Task> GetById(int taskId);
    IResult Add(AddTaskDto addTaskDto);
    IResult Update(UpdateTaskDto updateTaskDto);
    IResult Delete(int taskId);
}