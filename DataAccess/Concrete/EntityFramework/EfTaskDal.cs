using Core.DataAccess.EntityFramework;
using Entities.Abstract;
using Entities.DTOs;
using Task = Entities.Concrete.Task;

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
                select new TaskDetailDto
                {
                    Id = t.Id,
                    TaskName = t.TaskName,
                    ProjectName = p.ProjectName,
                    AssignedEmployeeName = e.EmployeeName,
                    Status = t.Status,
                    CompletionDate = t.CompletionDate,
                    ManagerApproval = t.ManagerApproval
                };
            return result.ToList();
        }
    }
}