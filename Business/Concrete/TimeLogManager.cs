using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class TimeLogManager : ITimeLogService
    {
        ITimeLogDal _timeLogDal;

        public TimeLogManager(ITimeLogDal timeLogDal)
        {
            _timeLogDal = timeLogDal;
        }
        public IDataResult<List<TimeLog>> GetAll()
        {
            return new SuccessDataResult<List<TimeLog>>(_timeLogDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<TimeLog>> GetAllByEmployeeId(int employeeId)
        {
            return new SuccessDataResult<List<TimeLog>>(_timeLogDal.GetAll(t => t.EmployeeId == employeeId));
        }

        public IDataResult<List<TimeLog>> GetAllByTaskId(int taskId)
        {
            return new SuccessDataResult<List<TimeLog>>(_timeLogDal.GetAll(t => t.TaskId == taskId));
        }

        public IDataResult<List<TimeLogDetailDto>> GetTimeLogDetails()
        {
            return new SuccessDataResult<List<TimeLogDetailDto>>(_timeLogDal.GetTimeLogDetails());
        }

        public IDataResult<TimeLog> GetById(int timelogId)
        {
            return new SuccessDataResult<TimeLog>(_timeLogDal.Get(p => p.Id == timelogId));
        }

        public IResult Add(TimeLog timeLog)
        {
            _timeLogDal.Add(timeLog);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Update(TimeLog timeLog)
        {
            _timeLogDal.Update(timeLog);

            return new SuccessResult(Messages.ProductUpdated);
        }

        public IResult Delete(TimeLog timeLog)
        {
            _timeLogDal.Delete(timeLog);

            return new SuccessResult(Messages.ProductDeleted);
        }
    }
}
