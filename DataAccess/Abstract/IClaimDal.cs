using Core.DataAccess;
using Entities.Concrete;

namespace Entities.Abstract
{
    public interface IClaimDal : IEntityRepository<OperationClaim>
    {
    }
}
