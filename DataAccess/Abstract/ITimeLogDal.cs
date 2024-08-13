using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace Entities.Abstract;

public interface ITimeLogDal : IEntityRepository<TimeLog>
{
    List<TimeLogDetailDto> GetTimeLogDetails();
}