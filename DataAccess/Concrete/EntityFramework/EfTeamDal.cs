using Core.DataAccess.EntityFramework;
using Entities.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfTeamDal : EfEntityRepositoryBase<Team, WorkStatusContext>, ITeamDal
{
}