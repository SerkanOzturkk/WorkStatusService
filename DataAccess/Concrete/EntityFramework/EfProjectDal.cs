using Core.DataAccess.EntityFramework;
using Entities.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfProjectDal : EfEntityRepositoryBase<Project, WorkStatusContext>, IProjectDal
{
}