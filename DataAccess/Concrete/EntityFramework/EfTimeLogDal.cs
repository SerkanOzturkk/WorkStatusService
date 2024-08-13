using Core.DataAccess.EntityFramework;
using Entities.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework;

public class EfTimeLogDal : EfEntityRepositoryBase<TimeLog, WorkStatusContext>, ITimeLogDal
{
    public List<TimeLogDetailDto> GetTimeLogDetails()
    {
        using (WorkStatusContext context = new WorkStatusContext())
        {
            var result = from tl in context.TimeLogs
                join e in context.Employees
                    on tl.EmployeeId equals e.Id
                join t in context.Tasks
                    on tl.TaskId equals t.Id
                select new TimeLogDetailDto
                {
                    Id = tl.Id,
                    EmployeeName = e.EmployeeName,
                    TaskName = t.TaskName,
                    Date = tl.Date,
                    HoursWorked = tl.HoursWorked,
                    OvertimeHours = tl.OvertimeHours
                };
            return result.ToList();
        }
    }
}