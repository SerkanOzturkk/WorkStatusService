using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace Entities.Abstract;

public interface IReportDal : IEntityRepository<Report>
{
    List<ReportDetailDto> GetReportDetails();
}