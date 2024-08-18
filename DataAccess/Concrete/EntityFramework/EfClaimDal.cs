using Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Entities.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfClaimDal : EfEntityRepositoryBase<OperationClaim,WorkStatusContext>,IClaimDal
    {
    }
}
