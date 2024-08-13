using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ReportManager : IReportService
    {
        IReportDal _reportDal;

        public ReportManager(IReportDal reportDal)
        {
            _reportDal = reportDal;
        }

        public IDataResult<List<Report>> GetAll()
        {
            return new SuccessDataResult<List<Report>>(_reportDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Report>> GetAllByTeamId(int teamId)
        {
            return new SuccessDataResult<List<Report>>(_reportDal.GetAll(r => r.TeamId == teamId));
        }

        public IDataResult<List<ReportDetailDto>> GetReportDetails()
        {
            return new SuccessDataResult<List<ReportDetailDto>>(_reportDal.GetReportDetails());
        }

        public IDataResult<Report> GetById(int reportId)
        {
            return new SuccessDataResult<Report>(_reportDal.Get(r => r.Id == reportId));
        }

        public IResult Add(Report report)
        {
            _reportDal.Add(report);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Update(Report report)
        {
            _reportDal.Update(report);

            return new SuccessResult(Messages.ProductUpdated);
        }

        public IResult Delete(Report report)
        {
            _reportDal.Delete(report);

            return new SuccessResult(Messages.ProductDeleted);
        }
    }
}
