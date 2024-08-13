using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface IReportService
{
    IDataResult<List<Report>> GetAll();
    IDataResult<List<Report>> GetAllByTeamId(int teamId);
    IDataResult<List<ReportDetailDto>> GetReportDetails();
    IDataResult<Report> GetById(int reportId);
    IResult Add(Report report);
    IResult Update(Report report);
    IResult Delete(Report report);
}