using Core.DataAccess;
using Entities.Concrete;

namespace Entities.Abstract;

public interface ITeamDal : IEntityRepository<Team>
{
}