using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace Entities.Abstract;

public interface ITeamDal : IEntityRepository<Team>
{
    List<TeamDetailDto> GetTeamDetails();
}