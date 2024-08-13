using Core.DataAccess.EntityFramework;
using Entities.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework;

public class EfReportDal : EfEntityRepositoryBase<Report, WorkStatusContext>, IReportDal
{
    public List<ReportDetailDto> GetReportDetails()
    {
        using (WorkStatusContext context = new WorkStatusContext())
        {
            var result = from r in context.Reports
                join t in context.Teams
                    on r.TeamId equals t.Id
                select new ReportDetailDto
                {
                    Id = r.Id,
                    ReportType = r.ReportType,
                    TeamName = t.TeamName,
                    ReportDate = r.ReportDate,
                    TotalTasksCompleted = r.TotalTasksCompleted,
                    TotalTasksPending = r.TotalTasksPending

                };
            return result.ToList();
        }
    }
}