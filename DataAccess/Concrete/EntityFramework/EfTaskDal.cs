using Core.DataAccess.EntityFramework;
using Entities.Abstract;
using Entities.DTOs;
using Task = Entities.Concrete.Task;
using TaskStatus = Entities.Concrete.TaskStatus;

namespace DataAccess.Concrete.EntityFramework;

public class EfTaskDal : EfEntityRepositoryBase<Task, WorkStatusContext>, ITaskDal
{
    public List<TaskDetailDto> GetTaskDetails()
    {
        using (WorkStatusContext context = new WorkStatusContext())
        {
            var result = from t in context.Tasks
                join p in context.Projects
                    on t.ProjectId equals p.Id
                join e in context.Employees
                    on t.AssignedEmployeeId equals e.Id
                join ts in context.TaskStatuses on t.TaskStatusId equals ts.Id 
                select new TaskDetailDto
                {
                    Id = t.Id,
                    TaskName = t.TaskName,
                    ProjectName = p.ProjectName,
                    AssignedEmployeeName = e.EmployeeName,
                    StatusName = ts.StatusName,
                    CompletionDate = t.CompletionDate,
                    ManagerApproval = t.ManagerApproval
                };
            return result.ToList();
        }
    }

    public List<GetTaskDto> GetTasksByEmployeeId(int employeeId)
    {
        using (WorkStatusContext context = new WorkStatusContext())
        {
            var result = from t in context.Tasks
                join p in context.Projects
                    on t.ProjectId equals p.Id
                join e in context.Employees
                    on t.AssignedEmployeeId equals e.Id
                join ts in context.TaskStatuses on t.TaskStatusId equals ts.Id 
                         where t.AssignedEmployeeId == employeeId
                select new GetTaskDto
                {
                    Id = t.Id,
                    TaskName = t.TaskName,
                    ProjectName = p.ProjectName,
                    AssignedEmployeeName = e.EmployeeName,
                    TaskStatusName = ts.StatusName,
                    CompletionDate = t.CompletionDate,
                    ManagerApproval = t.ManagerApproval
                };
            return result.ToList();
        }
    }
}