using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskStatus = Entities.Concrete.TaskStatus;

namespace DataAccess.Abstract
{
    public interface ITaskStatusService
    {
        IDataResult<List<TaskStatus>> GetAll();
        IDataResult<TaskStatus> GetById(int taskStatusId);
    }
}
