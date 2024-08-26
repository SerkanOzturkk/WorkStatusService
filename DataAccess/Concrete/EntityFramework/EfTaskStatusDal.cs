using Core.DataAccess.EntityFramework;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using TaskStatus = Entities.Concrete.TaskStatus;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTaskStatusDal : EfEntityRepositoryBase<TaskStatus, WorkStatusContext>, ITaskStatusDal
    {
    }
}
