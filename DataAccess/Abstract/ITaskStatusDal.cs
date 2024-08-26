using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using TaskStatus = Entities.Concrete.TaskStatus;

namespace DataAccess.Abstract
{
    public interface ITaskStatusDal : IEntityRepository<TaskStatus>
    {
    
    }
}
