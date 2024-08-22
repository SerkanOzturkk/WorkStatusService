using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Task = Entities.Concrete.Task;

namespace Business.Concrete
{
    public class TaskManager : ITaskService
    {
        ITaskDal _taskDal;
        public TaskManager(ITaskDal taskDal)
        {
            _taskDal = taskDal;
        }
        public IDataResult<List<Task>> GetAll()
        {
            return new SuccessDataResult<List<Task>>(_taskDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Task>> GetAllByAssignedEmployeeId(int assignedEmployeeId)
        {
            return new SuccessDataResult<List<Task>>(_taskDal.GetAll(t => t.AssignedEmployeeId == assignedEmployeeId));
        }

        public IDataResult<List<TaskDetailDto>> GetTaskDetails()
        {
            return new SuccessDataResult<List<TaskDetailDto>>(_taskDal.GetTaskDetails());
        }

        public IDataResult<Task> GetById(int taskId)
        {
            return new SuccessDataResult<Task>(_taskDal.Get(t => t.Id == taskId));
        }

        public IResult Add(AddTaskDto addTaskDto)
        {
            Task task = new Task();
            task.TaskName = addTaskDto.TaskName;
            task.ProjectId = addTaskDto.ProjectId;
            task.AssignedEmployeeId = addTaskDto.AssignedEmployeeId;
            task.Status = addTaskDto.Status;
            //task.CompletionDate = addTaskDto.CompletionDate  (not completed yet)
            task.ManagerApproval = false;
            task.CreatedDate = DateTime.Now;

            _taskDal.Add(task);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Update(Task task)
        {
            _taskDal.Update(task);

            return new SuccessResult(Messages.ProductUpdated);
        }

        public IResult Delete(Task task)
        {
            _taskDal.Delete(task);

            return new SuccessResult(Messages.ProductDeleted);
        }
    }
}
