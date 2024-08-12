using Core.DataAccess.EntityFramework;
using Entities.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfReportDal : EfEntityRepositoryBase<Report, WorkStatusContext>, IReportDal
{
}