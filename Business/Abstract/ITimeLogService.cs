using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface ITimeLogService
{
    IDataResult<List<TimeLog>> GetAll();
    IDataResult<List<TimeLog>> GetAllByEmployeeId(int employeeId);
    IDataResult<List<TimeLog>> GetAllByTaskId(int taskId);
    IDataResult<List<TimeLogDetailDto>> GetTimeLogDetails();
    IDataResult<TimeLog> GetById(int timelogId);
    IResult Add(TimeLog timeLog);
    IResult Update(TimeLog timeLog);
    IResult Delete(TimeLog timeLog);
}